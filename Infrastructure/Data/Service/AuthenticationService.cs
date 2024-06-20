using Application.Interfaces;
using Application.Models.Request;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Data.Service
{
    public class AuthenticationService : ICustomAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly AutenticacionServiceOptions _options;
        public AuthenticationService(IUserRepository userRepository, AutenticacionServiceOptions options)
        {
            _userRepository = userRepository;
            _options = options;
        }

        private User? ValidateUser(AuthenticationRequest authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.UserName) || string.IsNullOrEmpty(authenticationRequest.Password))
                return null;

            var user = _userRepository.GetUserByUserName(authenticationRequest.UserName);

            if (user == null) return null;

            if (authenticationRequest.UserType == typeof(Subscriber).Name || authenticationRequest.UserType == typeof(Musician).Name || authenticationRequest.UserType == typeof(Admin).Name)
            {
                if (user.Password == authenticationRequest.Password) return user;
            }

            return null;

        }

        public string Autenticar(AuthenticationRequest authenticationRequest)
        {
            var user = ValidateUser(authenticationRequest);

            if (user == null)
            {
                throw new InvalidOperationException("Authentication failed");
            }
            var securityPassword = new SymmetricSecurityKey()
        }
    }
    public class AutenticacionServiceOptions
    {
        public const string AutenticacionService = "AutenticacionService";

        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretForKey { get; set; }
    }
}
