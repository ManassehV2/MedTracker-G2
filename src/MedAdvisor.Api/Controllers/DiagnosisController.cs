using MedAdvisor.Api.DataClass;
using MedAdvisor.DataAccess.MySql.Interfaces;
using MedAdvisor.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedAdvisor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosisController:Controller
    {
        private readonly IUserDiagnosisRepository _repo;
        public DiagnosisController(IUserDiagnosisRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Diagnosis>))]
        public IActionResult GetDiagnosis()
        {
            var header = Request.Headers["Authentication"];
            int userid = UserFromToken.getId(header);

            try
            {
                ICollection<Diagnosis> result = _repo.GetUserDiagnoses(userid);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return Ok(result);
            }catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }

        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult AddDiagnosis([FromBody] DiagnosisData data)
        {
            if (data == null)
            {
                return BadRequest(ModelState);
            }
            try
            {
                bool result = _repo.AddDiagnosis(data.id, data.diagnosisid);
                if (!result)
                {
                    ModelState.AddModelError("", "bad request");
                    return BadRequest(ModelState);
                }
                return Ok("Successfully added");
            }catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);

            }


        }

        [HttpDelete]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteDiagnosis([FromBody] DiagnosisDeleteData dData)
        {
            if (dData == null)
            {
                return BadRequest(ModelState);
            }
            try
            {
                bool result = _repo.RemoveDiagnoses(dData.id, dData.diagnoses);
                if (!result)
                {
                    ModelState.AddModelError("", "bad request");
                    return BadRequest(ModelState);

                }
                return NoContent();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);

            }
        }
    }
}
