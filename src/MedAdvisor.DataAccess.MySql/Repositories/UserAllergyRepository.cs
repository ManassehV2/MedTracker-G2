using MedAdvisor.Models.Models;

namespace MedAdvisor.DataAccess.MySql.Repositories
{
    public class UserAllergyRepository : IUserAllergyRepository
    {
        private readonly MedTrackerContext _context;

        public UserAllergyRepository(MedTrackerContext context)
        {
            _context = context;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public ICollection<Allergy> GetUserAllergies(int id)
        {
            return _context.UserAllergies.Where(ud => ud.UserId == id).Select(ud => ud.Allergy).ToList();
        }

        private bool AllergyExists(int id)
        {
            return _context.Allergies.Any(p => p.Id == id);
        }

        private bool UserAllergyExists(int userId, int AllergyId)
        {
            return _context.UserAllergies.Any(p => p.UserId == userId && p.AllergyId == AllergyId);
        }

        public bool AddAllergy(int userId, int AllergyId)
        {
            if (!AllergyExists(AllergyId))
            {
                throw new Exception("Allergy Doesn't exist");
            }

            var Allergy = _context.Allergies.Where(di => di.Id == AllergyId).FirstOrDefault();
            var user = _context.Users.Where(di => di.Id == userId).FirstOrDefault();

            if (_context.UserAllergies.Any(ua => ua.UserId == userId && ua.AllergyId == AllergyId))
            {
                throw new Exception("Allergy Already Exists");
            }

            var userAllergy = new UserAllergy()
            {
                User = user,
                Allergy = Allergy
            };

            _context.Add(userAllergy);

            return Save();
        }

        public bool RemoveAllergies(int userId, List<int> Allergies)
        {
            if (Allergies.Any(AllergyId => !UserAllergyExists(userId, AllergyId)))
            {
                throw new Exception("One or more Invalid Fields");
            }

            foreach (int AllergyId in Allergies)
            {
                var userAllergy = _context.UserAllergies.Where(di => di.AllergyId == AllergyId && di.UserId == userId).FirstOrDefault();
                _context.Remove(userAllergy);
            }
            return Save();
        }
    }
}