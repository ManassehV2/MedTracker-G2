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

    }
}
