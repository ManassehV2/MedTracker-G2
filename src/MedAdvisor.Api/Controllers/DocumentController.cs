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
using static MedAdvisor.Models.Models.Document;

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
        public async Task<IActionResult> UploadFile(IFormFile file,DocumentData documentData,[FromHeader] string Authorization)
        {
            try {
                Console.Write(file.Length);
                var account = new Account(
                _configuration.GetSection("CloudinarySettings:CloudName").Value,
                _configuration.GetSection("CloudinarySettings:CloudName").Value,
                _configuration.GetSection("CloudinarySettings:CloudName").Value
            );

                var cloudinary = new Cloudinary(account);

                var fileStream = file.OpenReadStream();
                var fileName = file.FileName;


                var uploadParams = new RawUploadParams()
                {
                    File = new FileDescription(fileName, fileStream),
                };



                var uploadResult = await cloudinary.UploadAsync(uploadParams);
                Console.Write(uploadResult.SecureUrl);


                int userid = UserFromToken.getId(Authorization);

                if (uploadResult.Error == null)
                {
                    var createdDocument = new Document
                    {
                        FileName = uploadResult.SecureUri.AbsoluteUri,
                        Title = documentData.title,
                        UserId = userid,
                        Type = documentData.type,
                        Description = documentData.description
                    };

                    Console.Write(createdDocument.FileName);

                    _repository.Create(createdDocument);


                    return Ok();
                }
                else
                {
                    return BadRequest(uploadResult.Error.Message);
                }

            } catch (Exception ex) {

            return BadRequest(ex.Message);

            }
    }
}


}
