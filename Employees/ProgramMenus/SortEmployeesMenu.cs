// Menu class that allows sorting employees by different criteria. 

using Employees.Helpers;
using Employees.Services;
using Employees.Services.Comparers;

namespace Employees.ProgramMenus
{
    public class SortEmployeeMenu : IProgramMenu
    {
        private EmployeeService _employeeService;

        public SortEmployeeMenu(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public void ShowMenu()
        {
            Console.WriteLine("1. Posortuj rosnąco wg wieku");
            Console.WriteLine("2. Posortuj rosnąco wg doświadczenia");
            Console.WriteLine("3. Posortuj wg nazwiska i imienia");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    SortByAge();
                    break;
                case "2":
                    SortByExperience();
                    break;
                case "3":
                    SortByName();
                    break;
                default:
                    Console.WriteLine("Nieznana opcja.");
                    break;
            }
        }

        private void SortByAge()
        {
            var comparer = new AgeAscComparer();
            var sortedEmployees = _employeeService.GetAllEmployeesSortedByComparer(comparer);
            DisplayHelper.DisplayEmployee(sortedEmployees);
        }

        private void SortByExperience()
        {
            var comparer = new ExperienceAscComparer();
            var sortedEmployees = _employeeService.GetAllEmployeesSortedByComparer(comparer);
            DisplayHelper.DisplayEmployee(sortedEmployees);
        }

        private void SortByName()
        {
            var comparer = new SurnameThenFirstnameComparer();
            var sortedEmployees = _employeeService.GetAllEmployeesSortedByComparer(comparer);
            DisplayHelper.DisplayEmployee(sortedEmployees);
        }
    }
}
