// using System;
// using System.IO;
// using Microsoft.AspNetCore.Mvc;
// using CloudinaryDotNet;
// using CloudinaryDotNet.Actions;
// using Microsoft.Extensions.Configuration;
// using System.Threading.Tasks;
// using MedAdvisor.DataAccess.MySql;
// using MedAdvisor.Models.Models;

// namespace MedAdvisor.Api.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class DocumentUploadController : ControllerBase
//     {
//         private readonly IConfiguration _configuration;
//         private readonly MedTrackerContext _dbContext;

//         public DocumentUploadController(IConfiguration configuration, MedTrackerContext dbContext)
//         {
//             _configuration = configuration;
//             _dbContext = dbContext;
//         }

//         [HttpPost]
//         public async Task<IActionResult> UploadFile(IFormFile file)
//         {
//             Console.WriteLine("Start upload file");

//             var account = new Account(
//                 // _configuration["Cloudinary:dujpujpzk"],
//                 // _configuration["Cloudinary:935925156256877"],
//                 // _configuration["Cloudinary:0p2086y4v1UGju29GhXJlDTQgQ0"]
//                 "dujpujpzk",
//                 "935925156256877",
//                 "0p2086y4v1UGju29GhXJlDTQgQ0"


//             );

//             var cloudinary = new Cloudinary(account);

//             var fileStream = file.OpenReadStream();
//             var fileName = file.FileName;
//             Console.Write(fileStream);
//             Console.WriteLine(fileName);

//             var uploadParams = new ImageUploadParams()
//             {
//                 File = new FileDescription(fileName, fileStream),
//                 // Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
//             };
//             Console.Write(uploadParams);



//             var uploadResult = await cloudinary.UploadAsync(uploadParams);
//             Console.Write(uploadResult.SecureUrl);

            

//             if (uploadResult.Error == null)
//             {
//                 var fileRecord = new FileContent
//                 {
//                     FileName = uploadResult.SecureUri.AbsoluteUri
//                 };
//                 Console.Write(fileRecord.FileName);

//                 _dbContext.Files.Add(fileRecord);
//                 await _dbContext.SaveChangesAsync();

//                 return Ok();
//             }
//             else
//             {
//                 return BadRequest(uploadResult.Error.Message);
//             }
//         }
//     }
// }
