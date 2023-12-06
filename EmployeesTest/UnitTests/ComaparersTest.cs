// Unit tests for different classes of comparators for workers.
// The tests are for the comparators themselves
// The operation of the general sorting function is replaced here by calling OrderBy with a comparator on the list of employees

using Employees.Models;
using Employees.Services.Comparers;


namespace EmployeesTest.UnitTests
{
    [TestFixture]
    public class ComparatorsTest
    {
        private List<Employee> _employees;

        [SetUp]
        public void Setup()
        {
            _employees = new List<Employee>
            {
                new ManualWorker { Age = 30, Experience = 5, Name = "Jan", Surname = "Kowalski" },
                new OfficeEmployee { Age = 25, Experience = 3, Name = "Adam", Surname = "Kowalski" },
                new Trader { Age = 40, Experience = 7, Name = "Ewa", Surname = "Maj" }
            };
        }

        [Test]
        public void AgeAscComparer_ShouldSortEmployeesByAscendingAge()
        {
            var comparer = new AgeAscComparer();
            var sortedEmployees = _employees.OrderBy(e => e, comparer).ToList();

            Assert.IsTrue(sortedEmployees[0].Age <= sortedEmployees[1].Age);
            Assert.IsTrue(sortedEmployees[1].Age <= sortedEmployees[2].Age);
        }

        [Test]
        public void ExperienceAscComparer_ShouldSortEmployeesByAscendingExperience()
        {
            var comparer = new ExperienceAscComparer();
            var sortedEmployees = _employees.OrderBy(e => e, comparer).ToList();

            Assert.IsTrue(sortedEmployees[0].Experience <= sortedEmployees[1].Experience);
            Assert.IsTrue(sortedEmployees[1].Experience <= sortedEmployees[2].Experience);
        }

        [Test]
        public void SurnameThenFirstnameComparer_ShouldSortEmployeesBySurnameThenFirstname()
        {
            var comparer = new SurnameThenFirstnameComparer();
            var sortedEmployees = _employees.OrderBy(e => e, comparer).ToList();

            Assert.IsTrue(string.Compare(sortedEmployees[0].Surname, sortedEmployees[1].Surname) <= 0);
            Assert.IsTrue(string.Compare(sortedEmployees[1].Surname, sortedEmployees[2].Surname) <= 0);
            Assert.IsTrue(string.Compare(sortedEmployees[0].Name, sortedEmployees[1].Name) <= 0);
        }
    }
}
