// Comparator used to sort employees first by last name and then by first name.

using Employees.Models;

namespace Employees.Services.Comparers
{
    public class SurnameThenFirstnameComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            int surnameComparison = string.Compare(x.Surname, y.Surname);
            if (surnameComparison != 0)
            {
                return surnameComparison;
            }
            return string.Compare(x.Name, y.Name);
        }
    }
}
