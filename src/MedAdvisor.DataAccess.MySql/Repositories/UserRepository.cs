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

        public bool Exists(string email)
        {
            return _context.Users.Any(x => x.Email == email);
        }

        public User GetUserByEmail(string email)
        {
            if (!Exists(email))
            {
                throw new Exception("User doesn't exist");
            }
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }

        public User GetUser(int id)
        {
            return _context.Users.Where(p => p.Id == id).FirstOrDefault();
        }

        public bool CreateUser(User user)
        {
            _context.Users.Add(user);
            return Save();

        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateUser(int id, User updated_user)
        {
            var existing = GetUser(id);
            updated_user.HashedPassword = existing.HashedPassword;
            updated_user.Salt = existing.Salt;
            _context.Remove(existing);
            _context.Add(updated_user);
            return Save();

        }
    }
}