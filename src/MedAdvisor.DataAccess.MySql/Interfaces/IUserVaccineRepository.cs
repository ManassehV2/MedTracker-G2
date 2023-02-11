using MedAdvisor.Models.Models;


namespace MedAdvisor.DataAccess.MySql.Interfaces
{
    public interface IUserVaccineRepository
    {
        ICollection<Vaccine> GetUserVaccines(int id);

        bool AddVaccine(int userId, int vaccineId);

        bool RemoveVaccines(int userId, List<int> vaccines);
    }
}

