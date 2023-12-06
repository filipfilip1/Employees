// Value calculator for a Trader.
// Calculates the value of an employee based on his experience and efficiency.

using Employees.Models;

namespace Employees.Services.ValueStrategy
{
    public class TraderValueCalculator : IValueCalculator
    {
        public double CalculateValue(Employee employee)
        {
            var Trader = (Trader)employee;
            return Trader.Experience * (double)Trader.Efficiency;
        }

    }
}