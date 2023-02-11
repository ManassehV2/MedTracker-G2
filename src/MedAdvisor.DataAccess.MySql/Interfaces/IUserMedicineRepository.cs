using MedAdvisor.Models.Models;


namespace MedAdvisor.DataAccess.MySql.Interfaces
{
    public interface IUserMedicineRepository
    {
        ICollection<Medicine> GetUserMedicines(int id);

        bool AddMedicines(int id, List<Medicine> medicines);

        bool DeleteMedicine(int id, int medicine_id);
    }
}

