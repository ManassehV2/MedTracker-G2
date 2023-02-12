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
        public IActionResult GetMedicine()
        {
            var header = Request.Headers["Authentication"];
            int userid = UserFromToken.getId(header);

            try
            {

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

        public IActionResult AddMedicine([FromBody] MedicineData data)
        {
            if (data == null)
            {

                return BadRequest(ModelState);
            }
            try
            {
                bool result = _repo.AddMedicine(data.id, data.medicineId);
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
        public IActionResult DeleteMedicine([FromBody] MedicineDeleteData dData)
        {
            if (dData == null)
            {
                return BadRequest(ModelState);
            }
            try
            {
                bool result = _repo.RemoveMedicines(dData.id, dData.medicineId);
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