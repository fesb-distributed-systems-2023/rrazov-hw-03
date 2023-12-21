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



using Port.Models;

namespace Port.Repositories
{
    public interface IShipRepository
    {
        bool CreateNewShip(Ship ship);
        bool DeleteShip(int id);
        List<Ship> GetAllShips();
        Ship GetShipById(int id);
    }
}