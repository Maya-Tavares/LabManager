using Microsoft.Data.Sqlite;

namespace LabManager.Repositories;

class ComputerRepository
{
    private readonly DatabaseConfig databaseConfig;

    public List<Computer> GetAll()
    {
        var computers = new List<Computer>();

        var conection = new SqliteConnection(databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Computers";
        var reader = command.ExecuteReader();
            
            while(reader.Read())
            {
                var id = reader.GetInt32(0);
                var ram = reader.GetString(1);
                var processor = reader.GetString(2);
                var computer = new Computer(id, ram, processor);

                computers.Add(computer);
            }

            conection.Close();
            return computers;
        }
        

        public Computer GetById(int id)
        {
            var connection = new SqliteConnection(databaseConfig.ConnectionString);
            connection.Open();
        
        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Computers WHERE ID = ($id)";
        command.Parameters.AddWithValue("$id", id);
        var reader = command.ExecuteReader();

        reader.Read();
        var _id = reader.GetInt32(0);
        var ram = reader.GetString(1);
        var processor = reader.GetString(2);
        var computer = new Computer(_id, ram, processor);

        connection.Close();
        return computer;

        }


        public Computer Save(Computer computer)
            {
                var connection = new SqliteConnection(_databaseConfig.ConnectionString);
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Computers VALUES($id, $ram, $processor)";
                command.Parameters.AddWithValue("$id", computer.Id);
                command.Parameters.AddWithValue("$ram", computer.Ram);
                command.Parameters.AddWithValue("$processor", computer.Processor);

                command.ExecuteNonQuery();
                connection.Close();

                return computer;
            }


        public Computer Update(Computer computer)
        {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "UPDATE Computers SET ram = ($ram), processor = ($processor) WHERE ID = ($id)";
        command.Parameters.AddWithValue("$id", computer.Id);
        command.Parameters.AddWithValue("$ram", computer.Ram);
        command.Parameters.AddWithValue("$processor", computer.Processor);

        command.ExecuteNonQuery();
        connection.Close();

        return computer;
    }

}
