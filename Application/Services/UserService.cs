using System.Text.RegularExpressions;
using Domain.Interfaces;
using Domain.Entities;
using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Application.Common;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IOperationResultService _operationResultService;
        public UserService(IUserRepository userRepository, IMapper mapper, IOperationResultService operationResultService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _operationResultService = operationResultService;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
        public OperationResult CreateSubscriber(SubscriberDto subscriberDto)
        {
            if (!ValidatePassword(subscriberDto.Password))
            {
                return _operationResultService.CreateFailureResult("The password does not meet the requirements.");
            }
            var newSub = _mapper.Map<Subscriber>(subscriberDto);
            _userRepository.CreateSubscriber(newSub);
            _userRepository.SaveChanges();

            return _operationResultService.CreateSuccessResult("Subscriber created successfully");
        }
        public OperationResult CreateAdmin(AdminDto adminDto)
        {
            if (!ValidatePassword(adminDto.Password))
            {
                return _operationResultService.CreateFailureResult("The password does not meet the requirements.");
            }

            var newAdmin = _mapper.Map<Admin>(adminDto);
            _userRepository.CreateAdmin(newAdmin);
            _userRepository.SaveChanges();

            return _operationResultService.CreateSuccessResult("Admin created successfully");

        }
        public OperationResult CreateMusician(MusicianDto musicianDto)
        {
            if (!ValidatePassword(musicianDto.Password))
            {
                return _operationResultService.CreateFailureResult("The password does not meet the requirements.");
            }
            var newMusician = _mapper.Map<Musician>(musicianDto);
            _userRepository.CreateMusician(newMusician);
            return _operationResultService.CreateSuccessResult("Musician created successfully");
        }
        public OperationResult UpdateSubscriber(int id, SubscriberDto subscriber)
        {
            var existsUser = _userRepository.GetUserById(id);
            if (existsUser == null)
            {
                return _operationResultService.CreateFailureResult("User Not Found");
            }
            existsUser.UserName = subscriber.UserName;
            existsUser.Email = subscriber.Email;

            _userRepository.UpdateUser(existsUser);
            _userRepository.SaveChanges();
            return _operationResultService.CreateSuccessResult("Subscriber Updated successfully");
        }
        public OperationResult UpdateMusician(int id, MusicianDto musician)
        {
            var existsUser = _userRepository.GetUserById(id);
            if (existsUser == null)
            {
                return _operationResultService.CreateFailureResult("User Not Found");
            }
            existsUser.UserName = musician.UserName;
            existsUser.Email = musician.Email;

            _userRepository.UpdateUser(existsUser);
            _userRepository.SaveChanges();
            return _operationResultService.CreateSuccessResult("Musician Updated successfully");
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
            
            if (password.Length <= 6 || password.Length >= 12)
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
            if (!Regex.IsMatch(password, "[a-z]"))
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
