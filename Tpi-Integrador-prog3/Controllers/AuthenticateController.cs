using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace Tpi_Integrador_prog3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ICustomAuthenticacionService _customAuthenticationService;
        
        public AuthenticateController(IConfiguration config, ICustomAuthenticacionService autenticacionService)
        {
            _config = config;
            _customAuthenticationService = autenticacionService;
        }


        [HttpPost("authenticate")] 
        public ActionResult<string> Autenticar(AuthenticacionRequest authenticationRequest)
        {
            string token = _customAuthenticationService.Autenticar(authenticationRequest);

            return Ok(token);
        }

    }
}
