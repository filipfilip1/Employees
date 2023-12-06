// Unit tests for different filter classes for employees

using Employees.Models;
using Employees.Services.Filters;

namespace EmployeesTest.UnitTests
{
    [TestFixture]
    public class FiltersTest
    {
        private ManualWorker _manualWorker;
        private OfficeEmployee _officeEmployee;
        private Trader _trader;
        private WorkAddress _workAddress;
        private WorkAddress _workAddress2;

        [SetUp]
        public void Setup()
        {
            _workAddress = new WorkAddress { City = "Gdańsk" };
            _workAddress2 = new WorkAddress { City = "Sopot" };
            _manualWorker = new ManualWorker { Age = 30, WorkAddress = _workAddress };
            _officeEmployee = new OfficeEmployee { Age = 25, WorkAddress = _workAddress2 };
            _trader = new Trader { Age = 40, WorkAddress = _workAddress };
        }

        [Test]
        public void MatchByAge_ShouldMatchCorrectAgeRange()
        {
            var filter = new MatchByAge(25, 35);
            Assert.IsTrue(filter.Match(_officeEmployee)); 
            Assert.IsFalse(filter.Match(_trader)); 
        }

        [Test]
        public void MatchByCity_ShouldMatchCorrectCity()
        {
            var filter = new MatchByCity("Gdańsk");
            Assert.IsTrue(filter.Match(_manualWorker)); 
            Assert.IsFalse(filter.Match(_officeEmployee)); 
        }

        [Test]
        public void MatchByType_ShouldMatchCorrectEmployeeType()
        {
            var filterManualWorker = new MatchByType<ManualWorker>();
            var filterOfficeEmployee = new MatchByType<OfficeEmployee>();
            var filterTrader = new MatchByType<Trader>();

            Assert.IsTrue(filterManualWorker.Match(_manualWorker)); 
            Assert.IsFalse(filterManualWorker.Match(_officeEmployee)); 

            Assert.IsTrue(filterOfficeEmployee.Match(_officeEmployee)); 
            Assert.IsFalse(filterOfficeEmployee.Match(_trader));

            Assert.IsTrue(filterTrader.Match(_trader)); 
            Assert.IsFalse(filterTrader.Match(_manualWorker)); 
        }
    }
}
