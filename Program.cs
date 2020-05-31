using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;

namespace CompanyApi
{

    class Program
    {
        static void Main(string[] args)
        {
            CompanyConsoleApp app = new CompanyConsoleApp();
            int command;

            while(true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to company manager.\nAvailable coomands:\n");
                Console.WriteLine(" 1. Get all employees");
                Console.WriteLine(" 2. Get employee by his position in hierarchy");
                Console.WriteLine(" 3. Get employee with their subordinates by his position in hierarchy");
                Console.WriteLine(" 4. Add new employee");
                Console.WriteLine(" 5. Remove employee");
                Console.WriteLine(" 6. Add mock data to the databse");
                Console.WriteLine(" 7. Remove all employees");
                Console.WriteLine(" 8. Exit the app");

                Console.WriteLine("Your choice:");
                command = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Your command: " + command);
                
                switch(command)
                {
                    case 1:
                        Console.WriteLine("Getting employees");
                        app.GetEmployees();
                        break;
                    case 2:
                        Console.WriteLine("Getting employee");
                        app.GetEmployee();
                        break;
                    case 3:
                        Console.WriteLine("Getting employee with their subordinates");
                        app.GetEmployeeWithChildren();
                        break;
                    case 4:
                        Console.WriteLine("Adding employee");
                        app.AddEmployee();
                        break;
                    case 5:
                        Console.WriteLine("Removing Employee");
                        app.RemoveEmployee();
                        break;
                    case 6:
                        Console.WriteLine("Adding mock data to the database");
                        app.AddMockData();
                        break;
                    case 7:
                        Console.WriteLine("Removing all employees");
                        app.RemoveAllEmployees();
                        break;
                    case 8:
                        Environment.Exit(0);
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
