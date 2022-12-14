using MedAdvisor.Models.Models;

namespace MedAdvisor.DataAccess.MySql.Repositories
{
    public class DiagnosisRepository : IDiagnosisRepository
    {
        private readonly MedTrackerContext _context;

        public DiagnosisRepository(MedTrackerContext context)
        {
            _context = context;
        }

        public ICollection<Diagnosis> GetDiagnoses(string query)
        {
            return _context.Diagnosis.Where(p => p.Id.ToString().Contains(query) || p.Code.Contains(query) || p.Name.Contains(query)).ToList();
        }
    }
}