using Microsoft.Data.Sqlite;

namespace LabManager.Repositories;

class ComputerRepository
{
    public List<Computer> GetAll()
    {
        var computers = new List<Computer>();

    Console.WriteLine("Computer List");

           var reader = command.ExecuteReader();
            
            while(reader.Read())
            {
                var id = reader.GetInt32(0);
                var ram = reader.GetString(1);
                var processor = readerGetString(2);
                var computer = new ComputerRepository(3);

            }

           return computers;
        }

}
