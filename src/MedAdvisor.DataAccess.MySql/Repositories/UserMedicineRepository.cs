using MedAdvisor.Models.Models;

namespace MedAdvisor.DataAccess.MySql.Repositories
{
    public class UserMedicineRepository : IUserMedicineRepository
    {
        private readonly MedTrackerContext _context;

        public UserMedicineRepository(MedTrackerContext context)
        {
            _context = context;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public ICollection<Medicine> GetUserMedicines(int id)
        {
            return _context.UserMedicines.Where(ud => ud.UserId == id).Select(ud => ud.Medicine).ToList();
        }

        private bool MedicineExists(int id)
        {
            return _context.Medicines.Any(p => p.Id == id);
        }

        private bool UserMedicineExists(int userId, int MedicineId)
        {
            return _context.UserMedicines.Any(p => p.UserId == userId && p.MedicineId == MedicineId);
        }

        public bool AddMedicine(int userId, int MedicineId)
        {
            if (!MedicineExists(MedicineId))
            {
                throw new Exception("Medicine Doesn't exist");
            }

            var Medicine = _context.Medicines.Where(di => di.Id == MedicineId).FirstOrDefault();
            var user = _context.Users.Where(di => di.Id == userId).FirstOrDefault();

            if (_context.UserMedicines.Any(ua => ua.UserId == userId && ua.MedicineId == MedicineId))
            {
                throw new Exception("Medicine Already Exists");
            }

            var userMedicine = new UserMedicine()
            {
                User = user,
                Medicine = Medicine
            };

            _context.Add(userMedicine);

            return Save();
        }

        public bool RemoveMedicines(int userId, List<int> Medicines)
        {
            if (Medicines.Any(MedicineId => !UserMedicineExists(userId, MedicineId)))
            {
                throw new Exception("One or more Invalid Fields");
            }

            foreach (int MedicineId in Medicines)
            {
                var userMedicine = _context.UserMedicines.Where(di => di.MedicineId == MedicineId && di.UserId == userId).FirstOrDefault();
                _context.Remove(userMedicine);
            }
            return Save();
        }
    }
}