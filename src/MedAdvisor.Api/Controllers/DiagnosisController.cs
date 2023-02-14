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


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult AddDiagnosis([FromBody] DiagnosisData data, [FromHeader] string Authorization)

        {
            if (data == null)
            {

                return BadRequest(ModelState);
            }
            try
            {
                int userId = UserFromToken.getId(Authorization);
                bool result = _repo.AddDiagnosis(userId, data.diagnosisId);
                if (!result)
                {
                    ModelState.AddModelError("", "bad request");
                    return BadRequest(ModelState);
                }
                return Ok("Successfully added");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);

            }


        }

        [HttpPost("delete")]

        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteDiagnosis([FromBody] DiagnosisDeleteData dData, [FromHeader] string Authorization)

        {
            if (dData == null)
            {
                return BadRequest(ModelState);
            }
            try
            {
                int userId = UserFromToken.getId(Authorization);

                bool result = _repo.RemoveDiagnoses(userId, dData.diagnosisId);
                if (!result)
                {
                    ModelState.AddModelError("", "bad request");
                    return BadRequest(ModelState);

                }
                return NoContent();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);

            }
        }
    }
}