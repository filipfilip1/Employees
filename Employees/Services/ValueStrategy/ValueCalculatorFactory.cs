// Factory for employee value calculators.
// Responsible for creating appropriate value calculators based on employee type.

using Employees.Models;

namespace Employees.Services.ValueStrategy
{
    public class ValueCalculatorFactory : IValueCalculatorFactory
    {
        public IValueCalculator Create(Employee employee)
        {
            return employee switch
            {
                ManualWorker => new ManualWorkerValueCalculator(),
                OfficeEmployee => new OfficeEmployeeValueCalculator(),
                Trader => new TraderValueCalculator(),
                _ => throw new InvalidOperationException("Unknown type of employee")
            };

        }
    }
}
