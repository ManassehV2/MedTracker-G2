using MedAdvisor.Models.Models;


namespace MedAdvisor.DataAccess.MySql.Interfaces
{
    public interface IUserVaccineRepository
    {
        ICollection<Vaccine> GetUserVaccines(int id);

        bool AddVaccines(int id, List<Vaccine> Vaccines);

        bool RemoveVaccine(int id, int Vaccine_id);
    }
}

