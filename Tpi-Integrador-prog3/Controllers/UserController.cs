using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tpi_Integrador_prog3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetAllUsers")]
        //[Authorize("Admin")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpPost("CreateSubscriber")]
        //[Authorize("All")]
        public IActionResult CreateSub([FromBody] SubscriberDto subscriberDto)
        {
            _userService.CreateSubscriber(subscriberDto);
            return StatusCode(201);
        }

        [HttpPost("CreateAdmin")]
        //[Authorize("Admin")]
        public IActionResult CreateAdmin([FromBody] AdminDto adminDto)
        {
            _userService.CreateAdmin(adminDto);
            return StatusCode(201);
        }

        [HttpPost("CreateMusician")]
        //[Authorize("Admin")]
        public IActionResult CreateMusician([FromBody] MusicianDto musicianDto)
        {
            _userService.CreateMusician(musicianDto);
            return StatusCode(201);
        }
        [HttpPut("{idSubscriber}")]
        //[Authorize("Client")]
        public IActionResult UpdateSubscriber(int id, SubscriberDto subscriber)
        {
            _userService.UpdateSubscriber(id, subscriber);
            return Ok();
        }
        [HttpPut("{idMusician}")]
        //[Authorize("Client")]
        public IActionResult UpdateMusician(int id, MusicianDto musician)
        {
            _userService.UpdateMusician(id, musician);
            return Ok();
        }
        [HttpDelete("DeleteUserById/{id}")]
        //[Authorize("Admin")]
        public IActionResult DeleteUserById(int id)
        {
            _userService.DeleteUserById(id);
            return Ok("User Delete");
        }
        [HttpDelete("DeleteUserByEmail/{email}")]
        //[Authorize("Admin")]
        public IActionResult DeleteUserByEmail(string email)
        {
            _userService.DeleteUserByEmail(email);
            return Ok("User Delete");
        }

        [HttpGet("GetUserByUsername/{username}")]
        //[Authorize("Admin")]
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
        //[Authorize("Admin")]
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
