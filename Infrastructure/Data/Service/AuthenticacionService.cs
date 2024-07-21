using Application.Interfaces;
using Application.Models.Request;
using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Data.Service
{
    public class AuthenticacionService : ICustomAuthenticacionService
    {
        private readonly IUserRepository _userRepository;
        private readonly AutenticacionServiceOptions _options;
        private readonly IOperationResultService _operationResultService;
        public AuthenticacionService(IUserRepository userRepository, IOptions<AutenticacionServiceOptions> options, IOperationResultService operationResultService)
        {
            _userRepository = userRepository;
            _options = options.Value;
            _operationResultService = operationResultService;

        }

        public User? ValidateUser(AuthenticacionRequest authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.UserName) || string.IsNullOrEmpty(authenticationRequest.Password))
                return null;

            var user = _userRepository.GetUserByUserName(authenticationRequest.UserName);

            if (user == null) return null;

            if (user.Password == authenticationRequest.Password)
            {
                return user;
            }

            return null;
        }
        public string Autenticar(AuthenticacionRequest authenticationRequest)
        {
            var user = ValidateUser(authenticationRequest);
            if (user == null)
            {
                _operationResultService.CreateFailureResult("User authentication failed");
            }

            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.SecretForKey));

            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>
            {
                new Claim("sub", user.Id.ToString()),
                new Claim("UserName", user.UserName),
                new Claim("role", user.UserType.ToString())
            };

            var jwtSecurityToken = new JwtSecurityToken(
              _options.Issuer,
              _options.Audience,
              claimsForToken,
              DateTime.UtcNow,
              DateTime.UtcNow.AddHours(1),
              credentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return tokenToReturn;
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
