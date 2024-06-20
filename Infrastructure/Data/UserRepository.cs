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
            _context.SaveChanges();
        }
        public void CreateAdmin(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public void CreateMusician(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public User? GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public BaseResponse ValidateUser(Authenticate authenticate)
        {
            BaseResponse response = new BaseResponse();
            User? user = _context.Users.SingleOrDefault(u => u.UserName == authenticate.UserName);
            if (user != null)
            {
                if (user.Password == authenticate.Password)
                {
                    response.Result = true;
                    response.Message = "Logged In";
                }
                else
                {
                    response.Result = false;
                    response.Message = "Incorrect Password";
                }
            }
            else
            {
                response.Result = false;
                response.Message = "Incorrect Email";
            }
            return response;
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
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
