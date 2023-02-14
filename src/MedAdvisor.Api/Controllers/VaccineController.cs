using MedAdvisor.Api.DataClass;
using MedAdvisor.DataAccess.MySql;
using MedAdvisor.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedAdvisor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineController : Controller
    {
        private readonly IUserVaccineRepository _repo;
        public VaccineController(IUserVaccineRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Vaccine>))]
        public IActionResult GetVaccine([FromHeader] string Authorization)

        {
            try
            {
                int userid = UserFromToken.getId(Authorization);


                ICollection<Vaccine> result = _repo.GetUserVaccines(userid);


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

        public IActionResult AddVaccine([FromBody] VaccineData data, [FromHeader] string Authorization)

        {
            if (data == null)
            {

                return BadRequest(ModelState);
            }
            try
            {
                int userId = UserFromToken.getId(Authorization);
                bool result = _repo.AddVaccine(userId, data.vaccineId);
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
        public IActionResult DeleteVaccine([FromBody] VaccineDeleteData dData, [FromHeader] string Authorization)

        {
            if (dData == null)
            {
                return BadRequest(ModelState);
            }
            try
            {
                int userId = UserFromToken.getId(Authorization);

                bool result = _repo.RemoveVaccines(userId, dData.vaccineId);
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