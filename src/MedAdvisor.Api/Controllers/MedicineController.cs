using MedAdvisor.Api.DataClass;
using MedAdvisor.DataAccess.MySql;
using MedAdvisor.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedAdvisor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : Controller
    {
        private readonly IUserMedicineRepository _repo;
        public MedicineController(IUserMedicineRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Medicine>))]
        public IActionResult GetMedicine([FromHeader] string Authorization)

        {
            try
            {
                int userid = UserFromToken.getId(Authorization);


                ICollection<Medicine> result = _repo.GetUserMedicines(userid);


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

        public IActionResult AddMedicine([FromBody] MedicineData data, [FromHeader] string Authorization)

        {
            if (data == null)
            {

                return BadRequest(ModelState);
            }
            try
            {
                int userId = UserFromToken.getId(Authorization);
                bool result = _repo.AddMedicine(userId, data.medicineId);
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
        public IActionResult DeleteMedicine([FromBody] MedicineDeleteData dData, [FromHeader] string Authorization)

        {
            if (dData == null)
            {
                return BadRequest(ModelState);
            }
            try
            {
                int userId = UserFromToken.getId(Authorization);

                bool result = _repo.RemoveMedicines(userId, dData.medicineId);
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