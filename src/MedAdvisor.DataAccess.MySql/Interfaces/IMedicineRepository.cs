using MedAdvisor.Models.Models;

namespace MedAdvisor.DataAccess.MySql
{
    public interface IMedicineRepository
    {
        ICollection<Medicine> GetMedicines(string query);
    }
}

