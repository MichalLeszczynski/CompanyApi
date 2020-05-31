using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyApi
{
    class CompanyConsoleApp
    {
        private Company company;
        public CompanyConsoleApp()
        {
            company = new Company();
        }
        public void GetEmployees()
        {
            company.GetEmployees().ForEach(e => e.Print());
        }
        public void GetEmployee()
        {
            Console.WriteLine("Pass the hierarchyid of the employee:");
            company.GetEmployee(Console.ReadLine()).Print();
        }

        public void GetEmployeeWithChildren()
        {
            Console.WriteLine("Pass the hierarchyid of the employee:");
            company.GetEmployeeWithChildren(Console.ReadLine()).ForEach(e => e.Print());
        }

        public void AddEmployee()
        {
            string Level;
            string Name;
            string Position;
            int Salary;
            Console.WriteLine("Pass the hierarchyid of the employee:");
            Level = Console.ReadLine();

            Console.WriteLine("Pass the name of the employee:");
            Name = Console.ReadLine();

            Console.WriteLine("Pass the position name of the employee:");
            Position = Console.ReadLine();

            Console.WriteLine("Pass the salary of the employee:");
            Salary = Convert.ToInt32(Console.ReadLine());

            company.AddEmployee(Level, Name, Position, Salary);
        }

        public void RemoveEmployee()
        {
            Console.WriteLine("Pass the hierarchyid of the employee:");
            company.RemoveEmployee(Console.ReadLine());
        }

        public void RemoveAllEmployees()
        {
            company.RemoveAllEmployees();
        }
        public void GetSalary()
        {
            int command;
            Console.Clear();
            Console.WriteLine("Available statistics: ");
            Console.WriteLine(" 1. Maximum salary");
            Console.WriteLine(" 2. Average salary");
            Console.WriteLine(" 3. Sum salary");

            Console.WriteLine("Your choice:");
            command = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Your command: " + command);

            switch (command)
            {
                case 1:
                    Console.WriteLine("Max salary: " + company.GetMaxSalary());
                    break;
                case 2:
                    Console.WriteLine("Average salary: " + company.GetAverageSalary());
                    break;
                case 3:
                    Console.WriteLine("Sum salary: " + company.GetSumSalary());
                    break;
                }
            }

        public void AddMockData()
        {
            company.AddEmployee("/", "Mark Hamilton", "CEO", 20000);
            company.AddEmployee("/1/", "James Smith", "Vice President Finance", 15000);

            company.AddEmployee("/1/1/", "Maria Garcia", "Chief Accountant", 10000);
            company.AddEmployee("/1/2/", "Maria Rodriguez", "Chief Accountant", 9000);
            company.AddEmployee("/1/3/", "Mary Smith", "Junior Accountant", 8000);


            company.AddEmployee("/2/", "James Johnson", "Vice President Manufacturing", 13000);

            company.AddEmployee("/2/1/", "John Moore", "Plant Manager", 5000);
            company.AddEmployee("/2/2/", "Adam Nelson", "Plant Manager", 4000);
            company.AddEmployee("/2/2/1/", "Garry Baker", "Maintanance Supervisor", 3000);


            company.AddEmployee("/3/", "Hilda Hall", "Vice President Marketing", 12000);

            company.AddEmployee("/3/1/", "Selena Gomez", "Sales Manager", 8000);
            company.AddEmployee("/3/2/", "David Diaz", "Advertising Manager", 7000);
            company.AddEmployee("/3/2/1/", "Michael Parker", "Account Executive", 3000);
        }

    }
}
