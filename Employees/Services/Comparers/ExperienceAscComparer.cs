// Comparator used to sort employees by experience in ascending order.

using Employees.Models;


namespace Employees.Services.Comparers
{
    public class ExperienceAscComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return x.Experience.CompareTo(y.Experience);
        }
    }
}
