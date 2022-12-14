using MedAdvisor.Models.Models;


namespace MedAdvisor.DataAccess.MySql
{
    public interface IUserAllergyRepository
    {
        ICollection<Allergy> GetUserAllergies(int id);

        bool AddAllergy(int userId, int allergyId);

        bool RemoveAllergies(int userId, List<int> allergies);
    }
}