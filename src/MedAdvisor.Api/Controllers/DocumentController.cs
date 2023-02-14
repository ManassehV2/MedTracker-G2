using System.Reflection.Metadata;
using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using MedAdvisor.DataAccess.MySql;
using MedAdvisor.Models.Models;
using MedAdvisor.Api.DataClass;

namespace MedAdvisor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IDocumentRepository _repository;


        public DocumentController(IConfiguration configuration, IDocumentRepository repository)
        {
            _configuration = configuration;
            _repository = repository;

        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UploadFile([FromForm] DocumentData documentData, [FromHeader] string Authorization)
        {
            try
            {
                int userId = UserFromToken.getId(Authorization);
                var uploadResult = await CloudinaryUploadFile(documentData);
                var createdDocument = CreateDocumentObject(documentData, uploadResult.ToString(), userId);



                _repository.Create(createdDocument);
                return Ok("Document created successfully");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }
        public Models.Models.Document CreateDocumentObject(DocumentData documentData, string fileUrl, int userId)
        {
            var createdDocument = new Models.Models.Document
            {
                FileName = fileUrl,
                Title = documentData.title,
                UserId = userId,
                Type = documentData.type,
                Description = documentData.description!
            };
            return createdDocument;

        }


        public async Task<string> CloudinaryUploadFile(DocumentData documentData)
        {
            var account = new Account(
                    _configuration.GetSection("CloudinarySettings:CloudName").Value,
                    _configuration.GetSection("CloudinarySettings:ApiKey").Value,
                    _configuration.GetSection("CloudinarySettings:ApiSecret").Value
                );

            var cloudinary = new Cloudinary(account);

            var fileStream = documentData.file.OpenReadStream();
            var fileName = documentData.file.FileName;


            var uploadParams = new RawUploadParams()
            {
                File = new FileDescription(fileName, fileStream),
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            return uploadResult.SecureUri.AbsoluteUri;

        }


        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Get([FromHeader] string Authorization)
        {
            try
            {
                int userid = UserFromToken.getId(Authorization);
                var documents = _repository.GetMyDocuments(userid);
                return Ok(documents);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{documentId}")]

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult Delete([FromHeader] string Authorization, int documentId)
        {
            try
            {
                int userId = UserFromToken.getId(Authorization);
                Console.Write(documentId);
                var deleted = _repository.Delete(userId, documentId);
                return deleted ? Ok("Document deleted successfully") : throw new Exception("Document not deleted");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpPatch("{documentId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateDocument([FromHeader] string Authorization, [FromForm] DocumentData document, int documentId)

        {
            try
            {

                int userId = UserFromToken.getId(Authorization);

                var uploadResult = await CloudinaryUploadFile(document);

                var exsistingDocument = new Models.Models.Document
                {
                    Id = documentId,
                    FileName = uploadResult.ToString(),
                    Title = document.title,
                    UserId = userId,
                    Type = document.type,
                    Description = document.description!
                };
                _repository.Update(exsistingDocument);
                return Ok("Document updated successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{documentId}")]

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById([FromHeader] string Authorization, int documentId)
        {
            try
            {
                int userId = UserFromToken.getId(Authorization);

                var document = _repository.GetById(documentId);
                return Ok(document);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
