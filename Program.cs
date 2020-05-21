using System;
using System.Data.SqlClient;

namespace CompanyApi
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Company company1 = new Company();

            Console.WriteLine("\nAll employees:");
            company1.GetEmployees().ForEach(x => x.Print());

            Console.WriteLine("\nEmployee with its subordinates:");
            company1.getEmployeeWithChildren("/4/").ForEach(x => x.Print());

            Console.WriteLine("\nRemoving /4/1/:");
            company1.RemoveEmployee("/4/1/");

            Console.WriteLine("\nEmployee with its subordinates:");
            company1.getEmployeeWithChildren("/4/").ForEach(x => x.Print());

            Console.WriteLine("\nAdding /4/1/:");
            company1.AddEmployee("/4/1/", "Your Mama", "King");

            Console.WriteLine("\nEmployee with its subordinates:");
            company1.getEmployeeWithChildren("/4/").ForEach(x => x.Print());

        }
    }
}
