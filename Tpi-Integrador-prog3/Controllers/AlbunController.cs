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

    public class AlbunController : ControllerBase
    {
        private readonly IAlbunService _albunService;

        public AlbunController(IAlbunService albunService)
        {
            _albunService = albunService;
        }
        [HttpGet("GetAllAlbuns")]
        [Authorize("All")]
        public IActionResult GetAllAlbuns()
        {
            return Ok(_albunService.GetAllAlbun());
        }
        [HttpGet("GetAlbun/{albunId}")]
        [Authorize("All")]
        public IActionResult GetAlbunById([FromRoute]int albunId)
        {
            if(_albunService.GetAlbunById(albunId) == null)
            {
                return BadRequest("The Albun does not exist");
            }
            return Ok(_albunService.GetAlbunById(albunId));
        }
        [HttpPost("CreateAlbun")]
        [Authorize("Musician")]
        public IActionResult CreateAlbun([FromBody] AlbunDto albunDto)
        {
            var result = _albunService.CreateAlbun(albunDto);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpDelete("DeleteAlbun/{albunId}")]
        [Authorize("Musician")]
        public IActionResult DeleteAlbun([FromRoute] int albunId)
        {
            if (_albunService.GetAlbunById(albunId) == null)
            {
                return BadRequest("The Albun does not exist");
            }
            _albunService.DeleteAlbun(albunId);
            return Ok("Delete success");
        }
        [HttpPatch("UpdateAlbun/{albunId}")]
        [Authorize("Musician")]
        public IActionResult UpdateAlbun([FromRoute] int albunId ,[FromBody] AlbunDto albunDto)
        {
            var result = _albunService.UpdateAlbun(albunId,albunDto);
            if (result.Success)
            {
            _albunService.UpdateAlbun(albunId, albunDto);
            return Ok(result.Message);
            }
            else
            {
            return BadRequest(result.Message);
            }
        }
    }
}
