using Microsoft.SqlServer.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CompanyApi
{

    internal class Employee
    {
        public SqlHierarchyId Level;
        public string Name;
        public string Position;
       
        public Employee(SqlHierarchyId Level, string Name, string Position)
        {
            this.Level = Level;
            this.Name = Name;
            this.Position = Position;
        }

        public void print()
        {
            Console.WriteLine((Level.ToString() + "\t" + Position + "\t" + Name));
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

        internal List<Employee> getEmployees()
        {
            SqlCommand command = new SqlCommand("getAllEmployees", sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlDataReader result = command.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (result.Read())
            {
                employees.Add(new Employee(SqlHierarchyId.Parse((string)result["Level"]), (string)result["Position"], (string)result["Name"]));
            }
            result.Close();
            return employees;
        }
        internal List<Employee> getEmployeeWithChildren(string Level)
        {
            return getEmployees().Where(x => (bool)x.Level.IsDescendantOf(SqlHierarchyId.Parse(Level))).ToList();
        }

        public void addEmployee(string Level, string Name, string Position)
        {
            SqlCommand command = new SqlCommand("addEmployee", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Level", SqlDbType.Text).Value = Level.ToString();
            command.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
            command.Parameters.Add("@Position", SqlDbType.VarChar).Value = Position;

            command.ExecuteNonQuery();
        }

        public void removeEmployee(string Level)
        {
            SqlCommand command = new SqlCommand("removeEmployee", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Level", SqlDbType.VarChar).Value = Level;

            command.ExecuteNonQuery();
        }

    }
}