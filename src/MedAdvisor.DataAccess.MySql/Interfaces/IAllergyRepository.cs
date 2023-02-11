using MedAdvisor.Models.Models;


namespace MedAdvisor.DataAccess.MySql.Interfaces
{
    public interface IAllergyRepository
    {

        ICollection<Allergy> GetAllergies();
    }
}

