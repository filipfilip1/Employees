// Menu class to add or delete employees in a console application.

using Employees.Models;
using Employees.Services;

namespace Employees.ProgramMenus
{
    public class AddOrRemoveEmployeeMenu : IProgramMenu
    {
        private EmployeeService _employeeService;

        public AddOrRemoveEmployeeMenu(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public void ShowMenu()
        {
            Console.WriteLine("1. Dodaj pracownika");
            Console.WriteLine("2. Usuń pracownika wg Id");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddEmployeeFromMenu(_employeeService);
                    break;
                case "2":
                    RemoveEmployeeByIdFromMenu(_employeeService);
                    break;
                default:
                    Console.WriteLine("Nieznana opcja.");
                    break;
            }
        }

        private void RemoveEmployeeByIdFromMenu(EmployeeService employeeService)
        {
            Console.Write("Podaj id pracownika do usunięcia");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Nieprawidłowy format id");
                return;
            }

            bool result = employeeService.RemoveEmployeeById(id);
            Console.Write(result ? "Employee removed" : "Failed to remove employee");
        }

        private void AddEmployeeFromMenu(EmployeeService employeeService)
        {
            Console.WriteLine("Wybierz typ pracownika:");
            Console.WriteLine("1. Office Employee");
            Console.WriteLine("2. Manual Worker");
            Console.WriteLine("3. Trader");
            var employeeTypeChoice = Console.ReadLine();

            Employee employee;

            switch (employeeTypeChoice)
            {
                case "1":
                    employee = new OfficeEmployee();
                    break;
                case "2":
                    employee = new ManualWorker();
                    break;
                case "3":
                    employee = new Trader();
                    break;
                default:
                    Console.WriteLine("Nieznany typ pracownika.");
                    return;
            }

            Console.Write("Podaj imię: ");
            employee.Name = Console.ReadLine();

            Console.Write("Podaj nazwisko: ");
            employee.Surname = Console.ReadLine();

            Console.Write("Podaj wiek: ");
            employee.Age = int.Parse(Console.ReadLine());

            Console.Write("Podaj doświadczenie: ");
            employee.Experience = int.Parse(Console.ReadLine());

            if (employee is ManualWorker manualWorker)
            {
                Console.Write("Podaj siłę fizyczną: ");
                manualWorker.PhysicalStrength = int.Parse(Console.ReadLine());
            }
            else if (employee is OfficeEmployee officeEmployee)
            {
                Console.Write("Podaj poziom intelektu: ");
                officeEmployee.Intellect = int.Parse(Console.ReadLine());
            }
            else if (employee is Trader trader)
            {
                Console.Write("Podaj prowizję: ");
                trader.Comission = double.Parse(Console.ReadLine());

                Console.Write("Podaj efektywność (Low, Medium, High): ");
                trader.Efficiency = Enum.Parse<Efficiency>(Console.ReadLine(), true);
            }

            var workAddress = new WorkAddress();
            Console.Write("Podaj ulicę: ");
            workAddress.Street = Console.ReadLine();

            Console.Write("Podaj numer budynku: ");
            workAddress.BuildingNumber = Console.ReadLine();

            Console.Write("Podaj numer mieszkania (opcjonalnie): ");
            workAddress.ApartmentNumber = Console.ReadLine();

            Console.Write("Podaj miasto: ");
            workAddress.City = Console.ReadLine();

            employee.WorkAddress = workAddress;

            bool result = employeeService.AddEmployee(employee);
            Console.WriteLine(result ? "Pracownik dodany." : "Nie udało się dodać pracownika.");
        }
    }
}
