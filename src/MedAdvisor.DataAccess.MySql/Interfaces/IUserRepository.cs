using MedAdvisor.Models.Models;


namespace MedAdvisor.DataAccess.MySql.Interfaces
{
    public interface IUserRepository
    {

        User GetUser(int id);

        User UpdateUser(int id, User updated_user);

    }
}

