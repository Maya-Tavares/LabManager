// See https://aka.ms/new-console-template for more information
using LabManager.Database;
using Microsoft.Data.Sqlite;
using LabManager.Repositories;

    var databaseSetup = new DatabaseSetup();
    var computerRepository = new ComputerRepository();

    //Routing -- Roteamento

    var modelName = args[0];
    var modelAction = args[1];

    if(modelName == "Computer")
    {
        if(modelAction == "List")
        {
           Console.WriteLine("Computer List");
           foreach(var computer in computerRepository.GetAll())
           {
               Console.WriteLine("{0},{1},{2}", computer.Id, computer.Ram, computer.Processor);
           }
        }

        if(modelAction == "New")
        {

            var id = Convert.ToInt32(args[2]);
            string ram = args[3];
            string processor = args[4];

            var computer = new Computer(id, ram, processor);
            computerRepository.Save(computer);
        }

        if(modelAction == "Show")
        {

            var id = Convert.ToInt32(args[2]);
            var computer = ComputerRepository.GetById(id);
            Console.WriteLine($"{computer.Id}, {computer.Ram}, {computer.Processor}");

        }

        if(modelAction == "Update")
        {

            var id = Convert.ToInt32(args[2]);
            string ram = args[3];
            string processor = args[4];

            var computer = new Computer(id, ram, processor);
            computerRepository.Update(computer);
        }
    
        if(modelAction == "Delete")
        {

            var id = Convert.ToInt32(args[2]);
            computerRepository.Delete(id);
        }

        //var command = conection.CreateCommand();
        //command.CommandText = "INSERT INTO Computers VALUES($id, $ram, $processor)";
        //command.Parameters.AddWithValue("$id", id);
        //command.Parameters.AddWithValue("$ram", ram);
        //command.Parameters.AddWithValue("$processor",processor);
        //command.ExecuteNonQuery();

        //conection.Close();

        //Console.WriteLine("{0}, {1}, {2}", id, ram, processor);
        
    }