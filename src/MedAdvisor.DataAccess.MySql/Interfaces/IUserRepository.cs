using MedAdvisor.Models.Models;

namespace MedAdvisor.DataAccess.MySql
{
    public interface IUserRepository
    {

        bool Exists(string Email);
        User GetUser(int id);

        User GetUserByEmail(string email);
        bool CreateUser(User user);

        bool UpdateUser(int id, User updated_user);
    }
}