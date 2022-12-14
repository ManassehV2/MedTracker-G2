using MedAdvisor.Models.Models;


namespace MedAdvisor.DataAccess.MySql
{
    public interface IUserMedicineRepository
    {
        ICollection<Medicine> GetUserMedicines(int id);

        bool AddMedicine(int userId, int medicineId);

        bool RemoveMedicines(int userId, List<int> medicines);
    }
}

