using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(AlbunsContext context) : base(context)
        {
        }


        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }
        public void CreateSubscriber(User user)
        {
            _context.Users.Add(user);
            SaveChanges();
        }
        public void CreateAdmin(User user)
        {
            _context.Users.Add(user);
            SaveChanges();
        }
        public void CreateMusician(User user)
        {
            _context.Users.Add(user);
            SaveChanges();
        }
        public User? GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            SaveChanges();
        }
        public User? GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(e => e.Email == email);
        }

        public User? GetUserByUserName(string username)
        {
            return _context.Users.SingleOrDefault(u => u.UserName == username);
        }
    }
}
