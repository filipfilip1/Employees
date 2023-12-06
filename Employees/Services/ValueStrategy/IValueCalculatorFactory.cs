// Interface for the value calculator factory.

using Employees.Models;

namespace Employees.Services.ValueStrategy
{
    public interface IValueCalculatorFactory
    {
        public IValueCalculator Create(Employee employee);
    }
}
