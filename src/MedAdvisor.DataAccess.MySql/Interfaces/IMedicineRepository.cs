using MedAdvisor.Models.Models;


namespace MedAdvisor.DataAccess.MySql.Interfaces
{
    public interface IMedicineRepository
    {
        ICollection<Medicine> GetMedicines(string query);
    }
}

