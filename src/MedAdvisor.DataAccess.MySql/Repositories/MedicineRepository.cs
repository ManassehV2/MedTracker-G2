using MedAdvisor.Models.Models;

namespace MedAdvisor.DataAccess.MySql.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly MedTrackerContext _context;

        public MedicineRepository(MedTrackerContext context)
        {
            _context = context;
        }

        public ICollection<Medicine> GetMedicines(string query)
        {
            return _context.Medicines.Where(p => p.Id.ToString().Contains(query) || p.Code.Contains(query) || p.Name.Contains(query)).ToList();
        }
    }
}