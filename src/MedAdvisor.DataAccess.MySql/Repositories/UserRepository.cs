using MedAdvisor.Models.Models;

namespace MedAdvisor.DataAccess.MySql.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MedTrackerContext _context;

        public UserRepository(MedTrackerContext context)
        {
            _context = context;
        }

        public User GetUser(int id)
        {
            return _context.Users.Where(p => p.Id == id).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateUser(int id, User updated_user)
        {
            _context.Update(updated_user);
            return Save();

        }
    }
}