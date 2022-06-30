using LabManager.Database;
using LabManager.Models;
using Microsoft.Data.Sqlite;
using Dapper;

namespace LabManager.Repositories;

class ComputerRepository
{
    private readonly DatabaseConfig _databaseConfig;

    public ComputerRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }

     public IEnumerable<Computer> GetAll()
    {
        var computers = new List<Computer>();

        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        
        connection.Open();

        var computers = connection.Query<Computer>("SELECT * FROM Computers");
    
        
        return computers;
    }

    public Computer Save(Computer computer)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        connection.Execute("INSERT INTO Computers VALUES(@Id, @Ram, @Processor)", computer);
        
        return computer;
    }

    public Computer GetById(int id)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var computer = connection.QuerySingle<Computers>("SELECT * FROM Computers WHERE id = @Id");

        return computer;
    }

    public Computer Update(int id)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        connection.Execute("UPDATE Computers SET ram = @Ram, processor = @Processor WHERE id = @Id", new {Id = id});
       

        return computer;
    }

    public void Delete(int id)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        connection.Execute("DELTE FROM Computers WHERE id = @Id", new {Id = id});

    }

    public bool ExitsById(int id)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        return connection.ExecuteScalar<bool>("SELECT count(id) FROM Computers WHERE id = @Id", new {Id = id});

    }

}
