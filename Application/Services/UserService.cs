using System.Text.RegularExpressions;
using Domain.Interfaces;
using Domain.Entities;
using Application.Interfaces;
using Application.Models;
using AutoMapper;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
        public void CreateSubscriber(SubscriberDto subscriberDto)
        {
            if (!ValidatePassword(subscriberDto.Password))
            {
                throw new Exception("The password does not meet the requirements. it must have at least one number and one special character");
            }
            var newSub = _mapper.Map<Subscriber>(subscriberDto);
            _userRepository.CreateSubscriber(newSub);
            _userRepository.SaveChanges();
        }
        public void CreateAdmin(AdminDto adminDto)
        {
            if (!ValidatePassword(adminDto.Password))
            {
                throw new Exception("The password does not meet the requirements. it must have at least one number and one special character");
            }
            var newAdmin = _mapper.Map<Admin>(adminDto);
            _userRepository.CreateAdmin(newAdmin);
            _userRepository.SaveChanges();

        }
        public void CreateMusician(MusicianDto musicianDto)
        {
            if (!ValidatePassword(musicianDto.Password))
            {
                    throw new Exception("The password does not meet the requirements. it must have at least one number and one special character");
            }
            var newMusician = _mapper.Map<Musician>(musicianDto);
            _userRepository.CreateMusician(newMusician);
        }
        public void UpdateSubscriber(int id, SubscriberDto subscriber)
        {
            var existsUser = _userRepository.GetUserById(id);
            if (existsUser == null)
            {
                throw new Exception("User Not Found");
            }
            existsUser.UserName = subscriber.UserName;
            existsUser.Email = subscriber.Email;

            _userRepository.UpdateUser(existsUser);
            _userRepository.SaveChanges();
        }
        public void UpdateMusician(int id, MusicianDto musician)
        {
            var existsUser = _userRepository.GetUserById(id);
            if (existsUser == null)
            {
                throw new Exception("User Not Found");
            }
            existsUser.UserName = musician.UserName;
            existsUser.Email = musician.Email;

            _userRepository.UpdateUser(existsUser);
            _userRepository.SaveChanges();
        }
        public bool DeleteUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user != null)
            {
                _userRepository.DeleteUser(user);
                _userRepository.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteUserByEmail(string email)
        {
            var user = _userRepository.GetUserByEmail(email);
            if (user != null)
            {
                _userRepository.DeleteUser(user);
                _userRepository.SaveChanges();
                return true;
            }
            return false;
        }

        static bool ValidatePassword(string password)
        {
            if (password.Length <= 6 && password.Length >= 12)
            {
                return false;
            }
            if (password.Contains(" "))
            {
                return false;
            }
            if (!Regex.IsMatch(password, "[A-Z]"))
            {
                return false;
            }
            if (!Regex.IsMatch(password, "[a-zA-Z]"))
            {
                return false;
            }
            if (!Regex.IsMatch(password, "[0-9]"))
            {
                return false;
            }
            if (!Regex.IsMatch(password, "[!@#$%^&*(),.?\":{}|<>]"))
            {
                return false;
            }
            return true;
        }
        public User? GetUserByUserName(string username)
        {
            return _userRepository.GetUserByUserName(username);
        }
        public User? GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }
    }
}
