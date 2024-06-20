using Domain.Entities;
using Application.Models;

namespace Application.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        void CreateSubscriber(SubscriberDto subscriber);
        void CreateAdmin(AdminDto adminDto);
        void CreateMusician(MusicianDto musicianDto);
        void UpdateSubscriber(int id, SubscriberDto subscriber);
        void UpdateMusician(int id, MusicianDto musician);
        bool DeleteUserByEmail(string email);
        bool DeleteUserById(int id);
        User? GetUserByUserName(string username);
        User? GetUserByEmail(string email);

    }
}
