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
        public IActionResult GetAllergy()
        {
            var header = Request.Headers["Authentication"];
            int userid = UserFromToken.getId(header);

            try
            {

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


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult AddAllergy([FromBody] AllergyData data)
        {
            if (data == null)
            {

                return BadRequest(ModelState);
            }
            try
            {
                bool result = _repo.AddAllergy(data.id, data.allergyId);
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

        [HttpDelete]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteAllergy([FromBody] AllergyDeleteData dData)
        {
            if (dData == null)
            {
                return BadRequest(ModelState);
            }
            try
            {
                bool result = _repo.RemoveAllergies(dData.id, dData.AllergyId);
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