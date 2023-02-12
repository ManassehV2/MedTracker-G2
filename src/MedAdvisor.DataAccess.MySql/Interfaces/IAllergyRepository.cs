using MedAdvisor.Models.Models;


namespace MedAdvisor.DataAccess.MySql
{
    public interface IAllergyRepository
    {
        ICollection<Allergy> GetAllergies(string query);
    }
}

