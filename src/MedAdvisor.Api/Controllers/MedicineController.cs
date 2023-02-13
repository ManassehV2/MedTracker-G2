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


        
    }
}
