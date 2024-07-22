using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tpi_Integrador_prog3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AlbunController : ControllerBase
    {
        private readonly IAlbunService _albunService;

        public AlbunController(IAlbunService albunService)
        {
            _albunService = albunService;
        }
        [HttpGet("GetAllAlbuns")]
        public IActionResult GetAllAlbuns()
        {
            return Ok(_albunService.GetAllAlbun());
        }
        [HttpGet("GetAlbun/{albunId}")]
        public IActionResult GetAlbun([FromRoute]int albunId)
        {
            if(_albunService.GetAlbunById(albunId) == null)
            {
                return BadRequest("The Albun does not exist");
            }
            return Ok(_albunService.GetAlbunById(albunId));
        }
        [HttpPost("CreateAlbun")]
        public IActionResult CreateAlbun([FromBody] AlbunDto albunDto)
        {
            _albunService.CreateAlbun(albunDto);
            return Ok("Albun Created");
        }
        [HttpDelete("DeleteAlbun/{albunId}")]
        public IActionResult DeleteAlbun([FromRoute] int albunId)
        {
            _albunService.DeleteAlbun(albunId);
            return Ok("Delete success");
        }
        [HttpPut("UpdateAlbun")]
        public IActionResult UpdateAlbun([FromRoute] int albunId ,[FromBody] AlbunDto albunDto)
        {
            if (_albunService.GetAlbunById (albunId) == null)
            {
                return BadRequest("The Albun does not exist");
            }
            _albunService.UpdateAlbun(albunId, albunDto);
            return Ok("Albun Updated");
        }
    }
}
