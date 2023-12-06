// Unit tests for different employee value calculation strategies.

using Employees.Models;
using Employees.Services.ValueStrategy;

namespace EmployeesTest.UnitTests
{
    [TestFixture]
    public class ValueStrategyTest
    {
        private ManualWorker _manualWorker;
        private OfficeEmployee _officeEmployee;
        private Trader _trader;

        [SetUp]
        public void Setup()
        {
            _manualWorker = new ManualWorker { Experience = 5, PhysicalStrength = 10, Age = 30 };
            _officeEmployee = new OfficeEmployee { Experience = 3, Intellect = 100 };
            _trader = new Trader { Experience = 8, Efficiency = Efficiency.Medium };
        }

        [Test]
        public void ManualWorkerValueCalculator_ShouldCalculateCorrectValue()
        {
            var calculator = new ManualWorkerValueCalculator();
            double value = calculator.CalculateValue(_manualWorker);
            double expectedValue = _manualWorker.Experience * (double)(_manualWorker.PhysicalStrength / _manualWorker.Age);

            Assert.That(value, Is.EqualTo(expectedValue));
        }

        [Test]
        public void OfficeEmployeeValueCalculator_ShouldCalculateCorrectValue()
        {
            var calculator = new OfficeEmployeeValueCalculator();
            double value = calculator.CalculateValue(_officeEmployee);
            double expectedValue = _officeEmployee.Experience * _officeEmployee.Intellect;

            Assert.That(value, Is.EqualTo(expectedValue));
        }

        [Test]
        public void TraderValueCalculator_ShouldCalculateCorrectValue()
        {
            var calculator = new TraderValueCalculator();
            double value = calculator.CalculateValue(_trader);
            double expectedValue = _trader.Experience * (double)_trader.Efficiency;

            Assert.That(value, Is.EqualTo(expectedValue));
        }

        [Test]
        public void ValueCalculatorFactory_ShouldCreateCorrectCalculator()
        {
            var factory = new ValueCalculatorFactory();

            var calculatorForManualWorker = factory.Create(_manualWorker);
            Assert.IsInstanceOf<ManualWorkerValueCalculator>(calculatorForManualWorker);

            var calculatorForOfficeEmployee = factory.Create(_officeEmployee);
            Assert.IsInstanceOf<OfficeEmployeeValueCalculator>(calculatorForOfficeEmployee);

            var calculatorForTrader = factory.Create(_trader);
            Assert.IsInstanceOf<TraderValueCalculator>(calculatorForTrader);
        }
    }
}
