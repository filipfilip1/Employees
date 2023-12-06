// Unit tests for the EmployeeService class.
// Validate CRUD operations performed on employees, using the mocked interfaces IEmployeeRepository and IValueCalculatorFactory.

using Moq;
using Employees.Services;
using Employees.Models;
using Employees.Repositories;
using Employees.Services.ValueStrategy;

namespace EmployeesTest.UnitTests
{
    [TestFixture]
    public class EmployeeServiceTest
    {
        private Mock<IEmployeeRepository> _repositoryMock;
        private Mock<IValueCalculatorFactory> _valueCalculatorFactoryMock;
        private EmployeeService _employeeService;
        private List<Employee> _employeeList;
        private Employee _employee;


        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IEmployeeRepository>();
            _valueCalculatorFactoryMock = new Mock<IValueCalculatorFactory>();

            _employeeService = new EmployeeService(_repositoryMock.Object, _valueCalculatorFactoryMock.Object);

            _employee = new ManualWorker
            {
                Id = 1,
                Name = "Test",
                Surname = "Test",
                Age = 25,
                Experience = 5,
            };

            _employeeList = new List<Employee>
            {
                new ManualWorker { Id = 2, Name = "Jan", Surname = "Kowalski",  },
                new OfficeEmployee { Id = 3, Name = "Adam", Surname = "Nowak" },
                new Trader { Id = 4, Name = "Cezary", Surname = "Pazura" }
            };
        }


        // Checks that add employee returns True and that the method executed exactly once
        [Test]
        public void AddEmployee_ShouldReturnTrue_WhenEmployeeDoesNotExist()
        {
            _repositoryMock.Setup(rep => rep.GetById(It.IsAny<int>())).Returns((Employee)null);
            _repositoryMock.Setup(rep => rep.Add(It.IsAny<Employee>())).Returns(true);

            var result = _employeeService.AddEmployee(_employee);

            Assert.IsTrue(result);
            _repositoryMock.Verify(rep => rep.Add(It.Is<Employee>(emp => emp.Id == _employee.Id)), Times.Once);
        }

        // Checks that the AddEmployee method does not add an employee that already exists in the repository.
        // If the employee already exists the method should not execute
        [Test]
        public void AddEmployee_ShouldReturnFalse_WhenEmployeeExist()
        {
            _repositoryMock.Setup(rep => rep.GetById(It.IsAny<int>())).Returns(_employee);
            _repositoryMock.Setup(rep => rep.Add(It.IsAny<Employee>())).Returns(false);

            var result = _employeeService.AddEmployee(_employee);

            Assert.IsFalse(result);
            _repositoryMock.Verify(rep => rep.GetById(It.IsAny<int>()), Times.Once);
            _repositoryMock.Verify(rep => rep.Add(It.IsAny<Employee>()), Times.Never);

        }

        // Checks that the RemoveEmployeeById method returns True for an existing employee.
        [Test]
        public void RemoveEmployeeById_ShouldReturTrue_WhenEmployeeExist()
        {
            _repositoryMock.Setup(rep => rep.GetById(1)).Returns(_employee);

            var result = _employeeService.RemoveEmployeeById(1);

            Assert.IsTrue(result);
        }

        // Checks if the RemoveEmployeeById method returns False for a non-existing employee.
        // Should fail to execute if the employee does not exist
        [Test]
        public void RemoveEmployeeById_ShouldReturnFalse_WhenEmployeeDoesntExist()
        {
            _repositoryMock.Setup(rep => rep.GetById(1)).Returns((Employee)null);

            var result = _employeeService.RemoveEmployeeById(1);

            Assert.IsFalse(result);
            _repositoryMock.Verify(rep => rep.RemoveById(It.IsAny<int>()), Times.Never);
        }

        // Checks that the AddFewEmployee method returns the correct dictionary length and results for added employees.
        [Test]
        public void AddFewEmployee_ShouldReturnCorrectDictionaryLengthAndResult()
        {
            _repositoryMock.Setup(rep => rep.Add(It.IsAny<Employee>())).Returns(true);

            var result = _employeeService.AddFewEmployee(_employeeList[0], _employeeList[1]);

            Assert.That(result.Count, Is.EqualTo(2));
            Assert.IsTrue(result.All(res => res.Value));
        }
    }
}
