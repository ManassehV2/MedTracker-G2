using MedAdvisor.Models.Models;

namespace MedAdvisor.DataAccess.MySql
{
    public interface IVaccineRepository
    {
        ICollection<Vaccine> GetVaccines(string query);
    }
}

