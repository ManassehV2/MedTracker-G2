using MedAdvisor.Api.DataClass;
using MedAdvisor.DataAccess.MySql;
using MedAdvisor.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedAdvisor.Api.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemController : Controller
    {
        private readonly IUserDiagnosisRepository diagnosis_repo;
        private readonly IUserMedicineRepository medicine_repo;
        private readonly IUserVaccineRepository vaccine_repo;
        private readonly IUserAllergyRepository allergy_repo;


        public ItemController(IUserDiagnosisRepository dia_repo, IUserMedicineRepository med_repo,
        IUserVaccineRepository vac_repo, IUserAllergyRepository aller_repo)
        {
            diagnosis_repo = dia_repo;
            medicine_repo = med_repo;
            vaccine_repo = vac_repo;
            allergy_repo = aller_repo;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetItems([FromHeader] string Authorization)
        {
            try
            {
                int userId = UserFromToken.getId(Authorization);
                ICollection<ItemData> items = new List<ItemData>();
                ICollection<Allergy> allergies = allergy_repo.GetUserAllergies(userId);

                foreach(Allergy allergy in allergies){
                    items.Add(new ItemData(){
                        Id = allergy.Code,
                        Name = allergy.Name,
                        Type = "allergy"
                    });
                }
                ICollection<Vaccine> vaccines = vaccine_repo.GetUserVaccines(userId);
                foreach(Vaccine vaccine in vaccines){
                    items.Add(new ItemData(){
                        Id = vaccine.Code,
                        Name = vaccine.Name,
                        Type = "vaccine"
                    });
                }
                ICollection<Medicine> medicines = medicine_repo.GetUserMedicines(userId);
                foreach(Medicine medicine in medicines){
                    items.Add(new ItemData(){
                        Id = medicine.Code,
                        Name = medicine.Name,
                        Type = "medicine"
                    });
                }
                ICollection<Diagnosis> diagnoses = diagnosis_repo.GetUserDiagnoses(userId);

                foreach(Diagnosis diagnosis in diagnoses){
                    items.Add(new ItemData(){
                        Id = diagnosis.Code,
                        Name = diagnosis.Name,
                        Type = "diagnosis"
                    });
                }

                return Ok(items);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }

        }


    }
}