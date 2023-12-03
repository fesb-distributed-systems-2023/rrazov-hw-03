/*
**********************************
* Author: Roko Ražov
* Project Task: Port - Phase 2
**********************************
* Description:
* 
*    CREATE - Add new plane
*    READ - Get all planes
*    READ - Get specific plane
*    DELETE - Delete plane
*
**********************************
*/



using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Port.Models;
using Port.Repositories;

namespace Port.Controllers
{
    
    [ApiController]
    public class PortController : ControllerBase
    {
        private readonly PortRepository _portRepository;

        public PortController(PortRepository portRepository)
        {
            _portRepository = portRepository;
        }

        [HttpPost("/ports/new")]
        public IActionResult CreateNewPort([FromBody] Ports port) 
        {
            bool fSuccess = _portRepository.CreateNewPort(port);

            if(fSuccess) 
            {
                return Ok("New port created");
            }
            else 
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpGet("/ports/all")]
        public IActionResult GetAllPort() 
        {
            return Ok(_portRepository.GetAllPorts());   
        }

        [HttpGet("/ports/{id}")]
        public IActionResult GetPortById([FromRoute] int id) 
        {
            var port = _portRepository.GetPortById(id);

            if(port is null) 
            {
                return NotFound($"Port with id:{id} doesn't esxist");
            }
            else
            {
                return Ok(port);
            }
        }

        [HttpDelete("/ports/{id}")]
        public IActionResult DeletePort([FromRoute]int id) 
        {
            if(_portRepository.DeletePort(id))
            {
                return Ok($"Deleted port with id={id}!");
            }
            else
            {
                return NotFound($"Could not find port with id={id}");
            }
        }
    }
}
