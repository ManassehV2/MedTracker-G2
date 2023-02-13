using MedAdvisor.Models.Models;

namespace MedAdvisor.DataAccess.MySql.Repositories
{
    public class UserDiagnosisRepository : IUserDiagnosisRepository
    {
        private readonly MedTrackerContext _context;

        public UserDiagnosisRepository(MedTrackerContext context)
        {
            _context = context;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public ICollection<Diagnosis> GetUserDiagnoses(int id)
        {
            return _context.UserDiagnoses.Where(ud => ud.UserId == id).Select(ud => ud.Diagnosis).ToList();
        }

        private bool DiagnosisExists(int id)
        {
            return _context.Diagnosis.Any(p => p.Id == id);
        }

        private bool UserDiagnosisExists(int userId, int diagnosisId)
        {
            return _context.UserDiagnoses.Any(p => p.UserId == userId && p.DiagnosisId == diagnosisId);
        }

        public bool AddDiagnosis(int userId, int diagnosisId)
        {
            if (!DiagnosisExists(diagnosisId))
            {
                throw new Exception("Diagnosis Doesn't exist");
            }

            var diagnosis = _context.Diagnosis.Where(di => di.Id == diagnosisId).FirstOrDefault();
            var user = _context.Users.Where(di => di.Id == userId).FirstOrDefault();

            if (_context.UserDiagnoses.Any(ua => ua.UserId == userId && ua.DiagnosisId == diagnosisId))
            {
                throw new Exception("Diagnosis Already Exists");
            }

            var userDiagnosis = new UserDiagnosis()
            {
                User = user,
                Diagnosis = diagnosis
            };

            _context.Add(userDiagnosis);

            return Save();
        }

        public bool RemoveDiagnoses(int userId, List<int> diagnoses)
        {
            if (diagnoses.Any(diagnosisId => !UserDiagnosisExists(userId, diagnosisId)))
            {
                throw new Exception("One or more Invalid Fields");
            }

            foreach (int diagnosisId in diagnoses)
            {
                var userDiagnosis = _context.UserDiagnoses.Where(di => di.DiagnosisId == diagnosisId && di.UserId == userId).FirstOrDefault();
                _context.Remove(userDiagnosis);
            }
            return Save();
        }
    }
}