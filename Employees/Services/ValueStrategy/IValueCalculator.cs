// Interface for employee value calculators.
// Defines a CalculateValue method that calculates the value of an employee based on his attributes.
// Implements the strategy pattern

using Employees.Models;

namespace Employees.Services.ValueStrategy
{
    public interface IValueCalculator
    {
        double CalculateValue(Employee employee);
    }
}