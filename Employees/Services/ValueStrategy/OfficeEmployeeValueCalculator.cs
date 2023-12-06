// Value calculator for an OfficeEmployee.
// Calculates the value of an employee based on his experience and intellect.

using Employees.Models;

namespace Employees.Services.ValueStrategy
{
    public class OfficeEmployeeValueCalculator : IValueCalculator
    {
        public double CalculateValue(Employee employee)
        {
            var officeEmployee = (OfficeEmployee)employee;
            return officeEmployee.Experience * (double)officeEmployee.Intellect;
        }

    }
}