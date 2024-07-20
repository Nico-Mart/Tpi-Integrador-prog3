using Application.Models;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository : IRepository
    {
        IEnumerable<User> GetAllUsers();
        User? GetUserById(int userId);
        User? GetUserByUserName(string username);
        User? GetUserByEmail(string email);
        void CreateSubscriber(User user);
        void CreateAdmin(User user);
        void CreateMusician(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
