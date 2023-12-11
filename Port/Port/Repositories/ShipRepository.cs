/*
**********************************
* Author: Roko Ražov
* Project Task: Port - Phase 2
**********************************
* Description:
*  
*  Implement `IPortRepository` interface
*
**********************************
*/



using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Port.Models;



namespace Port.Repositories
{
    public class ShipRepository
    {
        private List<Ship> m_lstShip;
        public ShipRepository() 
        {
            m_lstShip = new List<Ship>();   
        }

        public bool CreateNewShip(Ship ship)
        {
            m_lstShip.Add(ship);

            return true;
        }

        public IEnumerable<Ship> GetAllShips() 
        {
            return m_lstShip;
        }

        public Ship GetShipById(int id) 
        {
            if(!m_lstShip.Any(ship => ship.Id == id))
            {
                return null;
            }
            var ship = m_lstShip.FirstOrDefault(ship => ship.Id == id);

            return ship;
        }

        public bool DeleteShip(int id) 
        {
            var itemToDelete = m_lstShip.FirstOrDefault(itemPort => itemPort.Id == id);
            if (itemToDelete == null) 
            {
                return false;
            }

            m_lstShip.Remove(itemToDelete);

            return true;
        }
    }
}
