// Comparator used to sort employees by age in ascending order.

using Employees.Models;

namespace Employees.Services.Comparers
{
    public class AgeAscComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
}
