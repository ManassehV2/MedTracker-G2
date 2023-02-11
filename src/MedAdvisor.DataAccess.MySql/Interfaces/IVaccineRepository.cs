using MedAdvisor.Models.Models;


namespace MedAdvisor.DataAccess.MySql.Interfaces
{
    public interface IVaccineRepository
    {
        ICollection<Vaccine> GetVaccines(string query);
    }
}

