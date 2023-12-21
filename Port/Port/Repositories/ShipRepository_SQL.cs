using Microsoft.Data.Sqlite;
using Port.Models;





namespace Port.Repositories

{
    public class ShipRepository_SQL : IShipRepository
    {
        private readonly string _connectionString = "Data Source=C:\\Users\\ROKO\\OneDrive - Fakultet elektrotehnike, strojarstva i brodogradnje\\Desktop\\FAKS\\DIS labovi\\rrazov-hw-03\\Port\\SQL\\database.db";
        //private readonly string _dbDatetimeFormat = "yyyy-MM-dd hh:mm:ss.fff";

        public bool CreateNewShip(Ship ship)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"
                INSERT INTO Ships (ShipName, PortName, DestinationName, TicketPrice, DepartureTime, ArrivalTime, DepartureStatus)
                VALUES ($shipName, $portName, $destinationName, $ticketPrice, $departureTime, $arrivalTime, $departureStatus)";

            command.Parameters.AddWithValue("$shipName", ship.ShipName);
            command.Parameters.AddWithValue("$portName", ship.PortName);
            command.Parameters.AddWithValue("$destinationName", ship.DestinationName);
            command.Parameters.AddWithValue("$ticketPrice", ship.TicketPrice);
            command.Parameters.AddWithValue("$departureTime", ship.DepartureTime);
            command.Parameters.AddWithValue("$arrivalTime", ship.ArrivalTime);
            command.Parameters.AddWithValue("$departureStatus", ship.DepartureStatus);


            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected < 1)
            {
                throw new ArgumentException("Could not insert ship into database.");
                return false;
                
            }
            return true;
        }

        public bool DeleteShip(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"
                DELETE FROM Ships
                WHERE ID == $id";

            command.Parameters.AddWithValue("$id", id);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected < 1)
            {
                throw new ArgumentException($"No ships with ID = {id}.");
                return false;
            }

            return true;
            
        }

        public List<Ship> GetAllShips()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"SELECT ID, ShipName, PortName, DestinationName, TicketPrice, DepartureTime, ArrivalTime, DepartureStatus FROM Ships";

            using var reader = command.ExecuteReader();

            var results = new List<Ship>();
            while (reader.Read())
            {

                var row = new Ship
                {
                    ID = reader.GetInt32(0),
                    ShipName = reader.GetString(1),
                    PortName = reader.GetString(2),
                    DestinationName= reader.GetString(3),
                    TicketPrice = reader.GetInt32(4),
                    DepartureTime = reader.GetInt32(5),
                    ArrivalTime = reader.GetInt32(6),
                    DepartureStatus = reader.GetString(7),
                };

                results.Add(row);
            }

            return results;
        }

        public Ship GetShipById(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"SELECT ID, ShipName, PortName, DestinationName, TicketPrice, DepartureTime, ArrivalTime, DepartureStatus FROM Ships WHERE ID == $id";

            command.Parameters.AddWithValue("$id", id);

            using var reader = command.ExecuteReader();

            Ship result = null;

            if (reader.Read())
            {
                result = new Ship()
                {
                    ID = reader.GetInt32(0),
                    ShipName = reader.GetString(1),
                    PortName = reader.GetString(2),
                    DestinationName = reader.GetString(3),
                    TicketPrice = reader.GetInt32(4),
                    DepartureTime = reader.GetInt32(5),
                    ArrivalTime = reader.GetInt32(6),
                    DepartureStatus = reader.GetString(7), 
                };
            }

            return result;
        }

    

 
    }
}

