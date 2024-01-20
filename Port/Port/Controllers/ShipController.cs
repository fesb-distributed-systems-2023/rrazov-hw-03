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
using Port.Filters;
using Port.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using Port.Controllers.DTO;
using Microsoft.AspNetCore.Http;




namespace Port.Controllers
{
    [ErrorFilter]
    [ApiController]
    [Route("api/[controller]")]
    public class ShipController : ControllerBase
    {
        private readonly IShipLogic _shipLogic;

        public ShipController(IShipLogic shipLogic)
        {
            this._shipLogic = shipLogic;
        }

        [HttpPost]
        public ActionResult Post([FromBody] NewShipDTO ship) 
        {
            if(ship == null)
            {
                return BadRequest($"Wrong ship format!");
            }

            _shipLogic.AddNewShip(ship.ToModel());

            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<ShipInfoDTO>> Get() 
        {
            var allShips = _shipLogic.GetShips().Select(x => ShipInfoDTO.FromModel(x));
            return Ok(allShips);
                   
        }

        [HttpGet("{id}")]
        public ActionResult<ShipInfoDTO> Get(int id) 
        {
            var ship = _shipLogic.GetShipById(id);

            if(ship is null) 
            {
                return NotFound($"Ship with id:{id} doesn't esxist");
            }
            else
            {
                return Ok(ShipInfoDTO.FromModel(ship));
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) 
        {
            var ship = _shipLogic.GetShipById(id);
            if(ship == null)
            {
                return NotFound($"Could not find ship with id={id}");
                return Ok($"Deleted ship with id={id}!");
            }
            else
            {
                _shipLogic.RemoveShip(id);
                return Ok($"Deleted ship with id={id}!");
            }
        }
    }
}
