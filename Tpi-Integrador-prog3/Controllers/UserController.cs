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

        [HttpPost("CreateSubscriber")]
        [Authorize("All")]
        public IActionResult CreateSub([FromBody] SubscriberDto subscriberDto)
        {
            var result = _userService.CreateSubscriber(subscriberDto);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return StatusCode(StatusCodes.Status201Created, result.Message);
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
            return StatusCode(StatusCodes.Status201Created, result.Message);
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
            return StatusCode(StatusCodes.Status201Created, result.Message);
        }
        [HttpPut("UpdateSubscriber/{idSubscriber}")]
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
        [HttpPut("UpdateMusician/{idMusician}")]
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
            _userService.DeleteUserById(id);
            return Ok("User Delete");
        }
        [HttpDelete("DeleteUserByEmail/{email}")]
        [Authorize("Admin")]
        public IActionResult DeleteUserByEmail(string email)
        {
            _userService.DeleteUserByEmail(email);
            return Ok("User Delete");
        }

        [HttpGet("GetUserByUsername/{username}")]
        [Authorize("Admin")]
        public IActionResult GetUserByUserName(string username)
        {
            var result = _userService.GetUserByUserName(username);
            if (result == null)
            {
                return BadRequest("User Not Found");
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
                return BadRequest("User Not Found");
            }
            return Ok(result);
        }

    }
}
