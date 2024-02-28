using Customers.API.DataBaseContext;
using Customers.API.Dto;
using Customers.API.Interfaces.Repository;
using Customers.API.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Customers.API.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly MyDataBaseContext _context;

        public UsersRepository(MyDataBaseContext context)
        {
            _context = context;
        }

        public bool CreateUser(User user)
        {
           _context.Add(user);
            return Save();
        }
       

        public bool DeleteUser(User user)
        {
            _context.Remove(user);
            return Save();
        }

        public ICollection<User> GetAllUsers()
        {
            var users= _context.Users.OrderBy(p => p.Id).ToList();
            return users;
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

        public bool UpdateUser(User user)
        {
            _context.Update(user);
            return Save();
        }

        public bool UserExists(int id)
        {
            return _context.Users.Any(p => p.Id == id);
        }

        public bool EmailExists(string  email)
        {
            return _context.Users.Any(p => p.Email == email);
        }
       

        public bool EmailExists(string email,int userId)
        {
            return _context.Users.Any(p => p.Email == email && p.Id!=userId) ;
        }

        public bool DniExists(long dni)
        {
            return _context.Users.Any(p => p.Dni == dni);
        }
        public bool DniExists(long dni, int userId)
        {
            return _context.Users.Any(p => p.Dni == dni && p.Id != userId);
        }
    }
}
