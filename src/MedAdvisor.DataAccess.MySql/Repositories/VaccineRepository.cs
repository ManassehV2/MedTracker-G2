using MedAdvisor.Models.Models;

namespace MedAdvisor.DataAccess.MySql.Repositories
{
    public class VaccineRepository : IVaccineRepository
    {
        private readonly MedTrackerContext _context;

        public VaccineRepository(MedTrackerContext context)
        {
            _context = context;
        }

        public ICollection<Vaccine> GetVaccines(string query)
        {
            return _context.Vaccines.Where(p => p.Id.ToString().Contains(query) || p.Code.Contains(query) || p.Name.Contains(query)).ToList();
        }
    }
}