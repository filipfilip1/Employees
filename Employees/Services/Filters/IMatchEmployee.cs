// An interface for employee filters.
// Defines a Match method that evaluates whether an employee meets the specified criteria.

using Employees.Models;

namespace Employees.Services.Filters
{
    public interface IMatchEmployee
    {
        public bool Match(Employee employee);
    }
}
