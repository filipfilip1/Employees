// Service that manages operations on employees
// Uses IEmployeeRepository to interact with the database
// Uses IValueFactory to calculate employee values

using Employees.Models;
using Employees.Repositories;
using Employees.Services.ValueStrategy;
using Employees.Services.Filters;


namespace Employees.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IValueCalculatorFactory _valueCalculatorFactory;

        // Constructor initializing the service with a repository and a value calculator factory.
        public EmployeeService(IEmployeeRepository repository, IValueCalculatorFactory valueCalculatorFactory)
        {
            _repository = repository;
            _valueCalculatorFactory = valueCalculatorFactory;
        }

        public bool AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException();
            }
            if (_repository.GetById(employee.Id) != null)
            {
                return false;
            }
            return _repository.Add(employee);
        }

        public bool RemoveEmployeeById(int Id)
        {
            var employee = _repository.GetById(Id);
            if (employee != null)
            {
                _repository.RemoveById(Id);
                return true;
            }
            return false;
        }


        // Adds several employees at once. Returns a dictionary with information about which employees were successfully added
        public Dictionary<string, bool> AddFewEmployee(params Employee[] employees)
        {
            var results = new Dictionary<string, bool>();  

            foreach(var employee in employees)
            {
                var result = _repository.Add(employee);
                results.Add($"{employee.Name} {employee.Surname}", result);
            }

            return results;
        }

        // Sorts the list of employees by the given comparator
        // Allows operations on an already modified Employee List
        public List<Employee> GetAllEmployeesSortedByComparer(IComparer<Employee> comparer, List<Employee> employees = null)
        {
            var allEmployees = employees ?? _repository.GetAll();
            return allEmployees.OrderBy(emp => emp, comparer).ToList();
        }

        // Filters employees by the given criterion
        // The criterion class must implement the IMatchEmployee interface
        // Allows operations on an already modified Employee List
        public List<Employee> GetEmployeesByFilter(IMatchEmployee filter, List<Employee> employees = null)
        {
            var allEmployees = employees ?? _repository.GetAll();
            return allEmployees.Where(emp => filter.Match(emp)).ToList();
        }


        // Calculates the values ​​of all employees and returns them in the dictionary.
        public Dictionary<(int Id, string Name, string Surname), double> CalculateAllEmployeValue()
        {
            return _repository.GetAll().ToDictionary(
                    emp => (emp.Id, emp.Name, emp.Surname),
                    emp =>
                    {
                        var valueCalculator = _valueCalculatorFactory.Create(emp);
                        return valueCalculator.CalculateValue(emp);
                    }
                    );
        }


    }
}
