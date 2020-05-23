using NUnit.Framework;


namespace CompanyApi
{
    [TestFixture]
    class CompanyApiTest
    {
        internal Company company;
        [SetUp]
        public void SetUp()
        {
            company = new Company();
            company.RemoveAllEmployees();
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


            company.AddEmployee("/4/", "Penelope Cruz", "Vice President HR", 11000);

            company.AddEmployee("/4/1/", "Sherlock Holmes", "HR Manager", 4000);
            company.AddEmployee("/4/2/", "Joseph Murphy", "Recruit Manager", 5000);

        }

        [TearDown]
        public void TearDown()
        {
            company.RemoveAllEmployees();
        }

        [Test]
        public void TestGetEmployees()
        {
            Assert.AreEqual(company.GetEmployees().Count, 16);
        }

        [Test]
        public void TestGetEmployee()
        {
            Employee employee = company.GetEmployee("/1/");
            Assert.AreEqual(employee.Name, "James Smith");
            Assert.AreEqual(employee.Position, "Vice President Finance");
            Assert.AreEqual(employee.Salary, 15000);
        }

        [Test]
        public void TestGetEmployeeWithChildren()
        {
            Assert.AreEqual(company.GetEmployeeWithChildren("/4/").Count, 3);
        }

        [Test]
        public void TestAddEmployee()
        {
            Assert.AreEqual(company.GetEmployees().Count, 16);
            company.AddEmployee("/6/", "Adam Nelson", "Plant Manager", 4000);
            Assert.AreEqual(company.GetEmployees().Count, 17);

            Assert.AreEqual(company.GetEmployee("/6/").Name, "Adam Nelson");
            Assert.AreEqual(company.GetEmployee("/6/").Position, "Plant Manager");
            Assert.AreEqual(company.GetEmployee("/6/").Salary, 4000);

            company.RemoveEmployee("/6/");
            Assert.AreEqual(company.GetEmployees().Count, 16);
        }

        [Test]
        public void TestRemoveEmployee()
        {
            Assert.AreEqual(company.GetEmployees().Count, 16);
            company.RemoveEmployee("/1/");
            Assert.AreEqual(company.GetEmployees().Count, 15);
            company.AddEmployee("/1/", "James Smith", "Vice President Finance", 15000);
            Assert.AreEqual(company.GetEmployees().Count, 16);
        }

        [Test]
        public void TestGetMaxSalary()
        {
            Assert.AreEqual(company.GetMaxSalary(), 20000);
        }

        [Test]
        public void TestGetAverageSalary()
        {
            Assert.AreEqual(company.GetAverageSalary(), 8562);
        }

        [Test]
        public void TestGetSumSalary()
        {
            Assert.AreEqual(company.GetSumSalary(), 137000);
        }

    }
}
