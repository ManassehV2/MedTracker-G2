using MedAdvisor.Api.DataClass;
using MedAdvisor.DataAccess.MySql;
using MedAdvisor.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedAdvisor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyController : Controller
    {
        private readonly IUserAllergyRepository _repo;
        public AllergyController(IUserAllergyRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Allergy>))]
        public IActionResult GetAllergy([FromHeader] string Authorization)

        {
            try
            {
                int userid = UserFromToken.getId(Authorization);


                ICollection<Allergy> result = _repo.GetUserAllergies(userid);


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