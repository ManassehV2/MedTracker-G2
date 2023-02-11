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
    }
}