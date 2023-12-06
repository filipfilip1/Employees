// Value calculator for a ManualWorker.
// Calculates the value of a worker based on his experience, physical strength and age.

using Employees.Models;

namespace Employees.Services.ValueStrategy
{
    public class ManualWorkerValueCalculator : IValueCalculator
    {
        public double CalculateValue(Employee employee)
        {
            var ManualWorker = (ManualWorker)employee;
            return ManualWorker.Experience * (double)(ManualWorker.PhysicalStrength / ManualWorker.Age);
        }

    }
}