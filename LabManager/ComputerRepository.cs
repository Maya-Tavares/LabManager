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

}
