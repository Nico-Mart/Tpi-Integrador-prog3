using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tpi_Integrador_prog3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetAllUsers")]
        [Authorize("Admin")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }
        [HttpGet("GetUserById/{userId}")]
        [Authorize("Admin")]
        public IActionResult GetUserById([FromRoute]int userId)
        {
            {
                if (_userService.GetUserById(userId) == null)
                {
                    return NotFound("The User does not exist");
                }
                return Ok(_userService.GetUserById(userId));
            }
        }

        [HttpPost("CreateSubscriber")]
        [AllowAnonymous]
        public IActionResult CreateSub([FromBody] SubscriberDto subscriberDto)
        {
            var result = _userService.CreateSubscriber(subscriberDto);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }

        [HttpPost("CreateAdmin")]
        [Authorize("Admin")]
        public IActionResult CreateAdmin([FromBody] AdminDto adminDto)
        {
            var result = _userService.CreateAdmin(adminDto);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }

        [HttpPost("CreateMusician")]
        [Authorize("Admin")]
        public IActionResult CreateMusician([FromBody] MusicianDto musicianDto)
        {
            var result = _userService.CreateMusician(musicianDto);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }

        [HttpPatch("UpdateSubscriber/{idSubscriber}")]
        [Authorize("Subscriber")]
        public IActionResult UpdateSubscriber(int idSubscriber, [FromBody] SubscriberDto subscriber)
        {
            var result = _userService.UpdateSubscriber(idSubscriber, subscriber);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }

        [HttpPatch("UpdateMusician/{idMusician}")]
        [Authorize("Musician")]
        public IActionResult UpdateMusician(int idMusician, [FromBody] MusicianDto musician)
        {
            var result = _userService.UpdateMusician(idMusician, musician);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }

        [HttpDelete("DeleteUserById/{id}")]
        [Authorize("Admin")]
        public IActionResult DeleteUserById(int id)
        {
            if (_userService.GetUserById(id) == null)
            {
                return NotFound("The User does not exist");
            }
            _userService.DeleteUserById(id);
            return Ok("User Deleted");
        }

        [HttpDelete("DeleteUserByEmail/{email}")]
        [Authorize("Admin")]
        public IActionResult DeleteUserByEmail(string email)
        {
            if (_userService.GetUserByEmail(email) == null)
            {
                return NotFound("The User does not exist");
            }
            _userService.DeleteUserByEmail(email);
            return Ok("User Deleted");
        }

        [HttpGet("GetUserByUsername/{username}")]
        [Authorize("Admin")]
        public IActionResult GetUserByUserName(string username)
        {
            var result = _userService.GetUserByUserName(username);
            if (result == null)
            {
                return NotFound("User Not Found");
            }
            return Ok(result);
        }

        [HttpGet("GeUserByEmail{email}")]
        [Authorize("Admin")]
        public IActionResult GetUserByEmail(string email)
        {
            var result = _userService.GetUserByEmail(email);
            if (result == null)
            {
                return NotFound("User Not Found");
            }
            return Ok(result);
        }

    }
}
