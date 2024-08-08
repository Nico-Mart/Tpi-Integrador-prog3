using Domain.Entities;
using Application.Models;
using Application.Common;

namespace Application.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User? GetUserById(int userId);
        OperationResult CreateSubscriber(SubscriberDto subscriber);
        OperationResult CreateAdmin(AdminDto adminDto);
        OperationResult CreateMusician(MusicianDto musicianDto);
        OperationResult UpdateSubscriber(int id, SubscriberDto subscriber);
        OperationResult UpdateMusician(int id, MusicianDto musician);
        bool DeleteUserByEmail(string email);
        bool DeleteUserById(int id);
        User? GetUserByUserName(string username);
        User? GetUserByEmail(string email);

    }
}
