using MedAdvisor.Api.DataClass;
using MedAdvisor.DataAccess.MySql;
using MedAdvisor.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedAdvisor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosisController : Controller
    {
        private readonly IUserDiagnosisRepository _repo;
        public DiagnosisController(IUserDiagnosisRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Diagnosis>))]
        public IActionResult GetDiagnosis([FromHeader] string Authorization)

        {
            try
            {
                int userid = UserFromToken.getId(Authorization);


                ICollection<Diagnosis> result = _repo.GetUserDiagnoses(userid);


                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                return Ok(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return BadRequest(ModelState);

            }

        }
    }
}