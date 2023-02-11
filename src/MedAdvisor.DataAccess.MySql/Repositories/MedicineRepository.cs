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
    }
}