using MedAdvisor.Models.Models;


namespace MedAdvisor.DataAccess.MySql.Interfaces
{
    public interface IUserAllergyRepository
    {
        ICollection<Allergy> GetUserAllergies(int id);

        bool AddAllergies(int id, List<Allergy> allergies);

        bool RemoveAllergy(int id, int allergy_id);
    }
}

