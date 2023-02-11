using MedAdvisor.Models.Models;


namespace MedAdvisor.DataAccess.MySql
{
    public interface IAllergyRepository
    {
        ICollection<Allergy> GetAllergies(string query);
        bool AddAllergy(int userId, int allergyId);

        bool RemoveAllergies(int id, List<Allergy> allergies);
    }
}

