// Menu class for filtering employees by various criteria. 

using Employees.Helpers;
using Employees.Models;
using Employees.Services;
using Employees.Services.Filters;

namespace Employees.ProgramMenus
{
    public class FilterEmployeeMenu : IProgramMenu
    {
        private EmployeeService _employeeService;

        public FilterEmployeeMenu(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public void ShowMenu()
        {
            Console.WriteLine("1. Wyświetl pracowników wg zakresu wieku");
            Console.WriteLine("2. Wyświetl pracowników z wybranego miasta");
            Console.WriteLine("3. Wyświetl pracowników wg typu");
            Console.WriteLine("4. Wyświetl wartości dla korporacji wszystkich pracowników");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    FilterByAgeRange();
                    break;
                case "2":
                    FilterByCity();
                    break;
                case "3":
                    FilterByType();
                    break;
                case "4":
                    DisplayAllEmployeesValue();
                    break;

                default:
                    Console.WriteLine("Nieznana opcja.");
                    break;
            }
        }

        private void FilterByAgeRange()
        {
            Console.Write("Podaj minimalny wiek: ");
            int minAge;
            if (!int.TryParse(Console.ReadLine(), out minAge))
            {
                Console.WriteLine("Nieprawidłowy wiek.");
                return;
            }

            Console.Write("Podaj maksymalny wiek: ");
            int maxAge;
            if (!int.TryParse(Console.ReadLine(), out maxAge))
            {
                Console.WriteLine("Nieprawidłowy wiek.");
                return;
            }

            var filter = new MatchByAge(minAge, maxAge);
            var employees = _employeeService.GetEmployeesByFilter(filter);
            DisplayHelper.DisplayEmployee(employees);
        }

        private void FilterByCity()
        {
            Console.Write("Podaj miasto: ");
            string city = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(city))
            {
                Console.WriteLine("Miasto nie może być puste.");
                return;
            }

            var filter = new MatchByCity(city);
            var employees = _employeeService.GetEmployeesByFilter(filter);
            DisplayHelper.DisplayEmployee(employees);
        }

        private void FilterByType()
        {
            Console.WriteLine("Wybierz typ pracownika:");
            Console.WriteLine("1. Office Employee");
            Console.WriteLine("2. Manual Worker");
            Console.WriteLine("3. Trader");
            var typeChoice = Console.ReadLine();

            switch (typeChoice)
            {
                case "1":
                    DisplayHelper.DisplayEmployee(_employeeService.GetEmployeesByFilter(new MatchByType<OfficeEmployee>()));
                    break;
                case "2":
                    DisplayHelper.DisplayEmployee(_employeeService.GetEmployeesByFilter(new MatchByType<ManualWorker>()));
                    break;
                case "3":
                    DisplayHelper.DisplayEmployee(_employeeService.GetEmployeesByFilter(new MatchByType<Trader>()));
                    break;
                default:
                    Console.WriteLine("Nieznany typ pracownika.");
                    break;
            }
        }

        private void DisplayAllEmployeesValue()
        {
            var employeeValues = _employeeService.CalculateAllEmployeValue();
            DisplayHelper.DisplayDictionary(employeeValues);
        }
    }
}
