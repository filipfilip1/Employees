// Employee filter that checks if the employee age is within a specified range.

using Employees.Models;

namespace Employees.Services.Filters
{
    public class MatchByAge : IMatchEmployee
    {
        private int _minAge;
        private int _maxAge;

        public MatchByAge(int minAge, int maxAge)
        {
            _minAge = minAge;
            _maxAge = maxAge;
        }

        public bool Match(Employee employee)
        {
            return employee.Age >= _minAge && employee.Age <= _maxAge;
        }

    }
}
