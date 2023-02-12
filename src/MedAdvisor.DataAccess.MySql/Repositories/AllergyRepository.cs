using MedAdvisor.Models.Models;

namespace MedAdvisor.DataAccess.MySql.Repositories
{
    public class AllergyRepository : IAllergyRepository
    {
        private readonly MedTrackerContext _context;

        public AllergyRepository(MedTrackerContext context)
        {
            _context = context;
        }

        public ICollection<Allergy> GetAllergies(string query)
        {
            return _context.Allergies.Where(p => p.Id.ToString().Contains(query) || p.Code.Contains(query) || p.Name.Contains(query)).ToList();
        }
    }
}