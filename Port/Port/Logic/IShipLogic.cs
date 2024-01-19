using Port.Models;

namespace Port.Logic
{
    public interface IShipLogic
    {
        public void AddNewShip(Ship ship);
        public void RemoveShip(int id);
        public Ship? GetShipById(int id);
        public IEnumerable<Ship> GetShips();





    }
}
