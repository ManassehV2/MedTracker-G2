using MedAdvisor.Models.Models;

namespace MedAdvisor.DataAccess.MySql
{
    public interface IUserRepository
    {
        User GetUser(int id);
        bool UpdateUser(int id, User updated_user);
    }
}