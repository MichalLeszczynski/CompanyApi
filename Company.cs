using Microsoft.SqlServer.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CompanyApi
{

    internal class Employee
    {
        public SqlHierarchyId Level;
        public string Name;
        public string Position;
        public int Salary;
       
        public Employee(SqlHierarchyId Level, string Name, string Position, int Salary)
        {
            this.Level = Level;
            this.Name = Name;
            this.Position = Position;
            this.Salary = Salary;
        }

        public void Print()
        {
            Console.WriteLine((Level.ToString() + "\t" + Position + "\t" + Name + "\t" + Salary));
        }
    }
    internal class Company
    {
        public SqlConnection sqlConnection = null;

        public Company()
        {
            string dbConnectionString = @"Data Source=185.238.75.42,11433;Initial Catalog=CompanyDB;User ID=SA;Password=Siema_123";

            sqlConnection = new SqlConnection(dbConnectionString);
            sqlConnection.Open();
        }

        internal List<Employee> GetEmployees()
        {
            SqlCommand command = new SqlCommand("GetAllEmployees", sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            using SqlDataReader result = command.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (result.Read())
            {
                employees.Add(new Employee((SqlHierarchyId)result["Level"], (string)result["Position"], (string)result["Name"], (int)result["Salary"]));
            }
            return employees;
        }

        internal Employee GetEmployee(string Level)
        {
            SqlCommand command = new SqlCommand("GetEmployee", sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add("@Level", SqlDbType.VarChar).Value = Level;

            using SqlDataReader result = command.ExecuteReader();
            result.Read();
            Employee employee = new Employee((SqlHierarchyId)result["Level"], (string)result["Name"], (string)result["Position"], (int)result["Salary"]);
            return employee;
        }

        internal List<Employee> GetEmployeeWithChildren(string Level)
        {
            SqlCommand command = new SqlCommand("GetEmployeeWithChildren", sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add("@Level", SqlDbType.VarChar).Value = Level;

            using SqlDataReader result = command.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (result.Read())
            {
                employees.Add(new Employee((SqlHierarchyId)result["Level"], (string)result["Name"], (string)result["Position"], (int)result["Salary"]));
            }
            return employees;
        }

        public void AddEmployee(string Level, string Name, string Position, int Salary)
        {
            SqlCommand command = new SqlCommand("AddEmployee", sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add("@Level", SqlDbType.VarChar).Value = Level;
            command.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
            command.Parameters.Add("@Position", SqlDbType.VarChar).Value = Position;
            command.Parameters.Add("@Salary", SqlDbType.Int).Value = Salary;


            command.ExecuteNonQuery();
        }

        public void RemoveEmployee(string Level)
        {
            SqlCommand command = new SqlCommand("RemoveEmployee", sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add("@Level", SqlDbType.VarChar).Value = Level;

            command.ExecuteNonQuery();
        }

        public void RemoveAllEmployees()
        {
            SqlCommand command = new SqlCommand("RemoveAllEmployees", sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.ExecuteNonQuery();
        }

        internal int GetSalary(string procedure_name)
        {
            SqlCommand command = new SqlCommand(procedure_name, sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            using SqlDataReader result = command.ExecuteReader();
            result.Read();
            int salary = (int)result["Salary"];
            return salary;
        }

        internal int GetMaxSalary()
        {
            return GetSalary("GetMaxSalary");
        }

        internal int GetAverageSalary()
        {
            return GetSalary("GetAverageSalary");
        }

        internal int GetSumSalary()
        {
            return GetSalary("GetSumSalary");
        }


    }
}