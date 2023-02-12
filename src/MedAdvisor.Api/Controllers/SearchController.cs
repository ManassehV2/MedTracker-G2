using MedAdvisor.Api.DataClass;
using MedAdvisor.DataAccess.MySql;
using MedAdvisor.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedAdvisor.Api.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : Controller
    {
        private readonly IDiagnosisRepository diagnosis_repo;
        private readonly IMedicineRepository medicine_repo;
        private readonly IVaccineRepository vaccine_repo;
        private readonly IAllergyRepository allergy_repo;
        public SearchController(IDiagnosisRepository dia_repo, IMedicineRepository med_repo,
        IVaccineRepository vac_repo, IAllergyRepository aller_repo)
        {
            diagnosis_repo = dia_repo;
            medicine_repo = med_repo;
            vaccine_repo = vac_repo;
            allergy_repo = aller_repo;
        }

        [HttpGet("vaccine")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Vaccine>))]
        public IActionResult SearchVaccine(string query = "")
        {
            try
            {
                ICollection<Vaccine> result = vaccine_repo.GetVaccines(query);

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


        [HttpGet("diagnosis")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Diagnosis>))]
        public IActionResult SearchDiagnosis(string query = "")
        {
            try
            {
                ICollection<Diagnosis> result = diagnosis_repo.GetDiagnoses(query);

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


        [HttpGet("medicine")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Medicine>))]
        public IActionResult SearchMedicine(string query = "")
        {
            try
            {
                ICollection<Medicine> result = medicine_repo.GetMedicines(query);

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

        [HttpGet("allergy")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Allergy>))]
        public IActionResult SearchAllergy(string query = "")
        {
            try
            {
                ICollection<Allergy> result = allergy_repo.GetAllergies(query);
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