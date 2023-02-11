using MedAdvisor.Models.Models;

namespace MedAdvisor.DataAccess.MySql.Repositories
{
    public class UserVaccineRepository : IUserVaccineRepository
    {
        private readonly MedTrackerContext _context;

        public UserVaccineRepository(MedTrackerContext context)
        {
            _context = context;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public ICollection<Vaccine> GetUserVaccines(int id)
        {
            return _context.UserVaccines.Where(ud => ud.UserId == id).Select(ud => ud.Vaccine).ToList();
        }

        private bool VaccineExists(int id)
        {
            return _context.Vaccines.Any(p => p.Id == id);
        }

        private bool UserVaccineExists(int userId, int VaccineId)
        {
            return _context.UserVaccines.Any(p => p.UserId == userId && p.VaccineId == VaccineId);
        }

        public bool AddVaccine(int userId, int VaccineId)
        {
            if (!VaccineExists(VaccineId))
            {
                throw new Exception("Vaccine Doesn't exist");
            }

            var Vaccine = _context.Vaccines.Where(di => di.Id == VaccineId).FirstOrDefault();
            var user = _context.Users.Where(di => di.Id == userId).FirstOrDefault();

            if (_context.UserVaccines.Any(ua => ua.UserId == userId && ua.VaccineId == VaccineId))
            {
                throw new Exception("Vaccine Already Exists");
            }

            var userVaccine = new UserVaccine()
            {
                User = user,
                Vaccine = Vaccine
            };

            _context.Add(userVaccine);

            return Save();
        }

        public bool RemoveVaccines(int userId, List<int> Vaccines)
        {
            if (Vaccines.Any(VaccineId => !UserVaccineExists(userId, VaccineId)))
            {
                throw new Exception("One or more Invalid Fields");
            }

            foreach (int VaccineId in Vaccines)
            {
                var userVaccine = _context.UserVaccines.Where(di => di.VaccineId == VaccineId && di.UserId == userId).FirstOrDefault();
                _context.Remove(userVaccine);
            }
            return Save();
        }
    }
}