// A class representing a trader
// Extends the base class with fields such as commission and performance

namespace Employees.Models
{
    // Enum representing efficiency in work
    public enum Efficiency
    {
        Low = 60,
        Medium = 90,
        High = 120
    }

    public class Trader : Employee
    {
        public double Comission {  get; set; }
        public Efficiency Efficiency { get; set; }
    }
}
