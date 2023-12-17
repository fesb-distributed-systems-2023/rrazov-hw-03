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
    public class ShipController : ControllerBase
    {
        private readonly ShipRepository _shipRepository;

        public ShipController(ShipRepository shipRepository)
        {
            _shipRepository = shipRepository;
        }

        [HttpPost("/ship/new")]
        public IActionResult CreateNewShip([FromBody] Ship ship) 
        {
            bool fSuccess = _shipRepository.CreateNewShip(ship);

            if(fSuccess) 
            {
                return Ok("New ship created");
            }
            else 
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpGet("/ship/all")]
        public IActionResult GetAllShips() 
        {
            return Ok(_shipRepository.GetAllShips());   
        }

        [HttpGet("/ship/{id}")]
        public IActionResult GetShipById([FromRoute] int id) 
        {
            var ship = _shipRepository.GetShipById(id);

            if(ship is null) 
            {
                return NotFound($"Ship with id:{id} doesn't esxist");
            }
            else
            {
                return Ok(ship);
            }
        }

        [HttpDelete("/ship/{id}")]
        public IActionResult DeleteShip([FromRoute]int id) 
        {
            if(_shipRepository.DeleteShip(id))
            {
                return Ok($"Deleted ship with id={id}!");
            }
            else
            {
                return NotFound($"Could not find ship with id={id}");
            }
        }
    }
}
