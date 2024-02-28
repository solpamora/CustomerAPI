using Customers.API.Dto;
using Customers.API.Models;

namespace Customers.API.Interfaces.Repository
{
    public interface IUsersRepository
    {
        ICollection<User> GetAllUsers();

        User GetUser(int id);

        bool CreateUser(User user);

        bool UserExists (int id);

        bool UpdateUser(User user);

        bool DeleteUser(User user);

        bool Save();

        bool EmailExists(string email);

        bool EmailExists(string email, int userId);

        bool DniExists(long dni);

        bool DniExists(long dni,int userId );
    }
}
