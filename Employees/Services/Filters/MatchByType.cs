// Employee filter that checks if an employee is of a specific type.
// Uses the generic type mechanism to determine the employee type.

using Employees.Models;


namespace Employees.Services.Filters
{
    public class MatchByType<T> : IMatchEmployee where T : Employee
    {
        public bool Match(Employee employee)
        {
            return employee is T;
        }
    }
}
