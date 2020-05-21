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

    }
}
