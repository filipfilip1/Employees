// The main class of the console employee management application.
// Responsible for user interaction, database and service context initialization.
// Creates and handles the main console menu


using Employees.Data;
using Employees.ProgramMenus;
using Employees.Repositories;
using Employees.Services;
using Employees.Services.ValueStrategy;


namespace Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialization of the database context
            using (var context = new EmployeeContext())
            {
                // Seeding of data
                DbSeed.Initialize(context);

                // Creating instances of the repository and services uses in the appliaction
                IEmployeeRepository repository = new EmployeeRepository(context);
                IValueCalculatorFactory valueCalculatorFactory = new ValueCalculatorFactory();
                EmployeeService employeeService = new EmployeeService(repository, valueCalculatorFactory);

                while (true)
                {
                    Console.WriteLine("Menu główne:");
                    Console.WriteLine("1. Dodaj lub usuń pracownika");
                    Console.WriteLine("2. Wyświetl pracowników według danego kryterium");
                    Console.WriteLine("3. Posortuj pracowników wg danego kryterium");
                    Console.WriteLine("4. Wyjście");

                    Console.Write("Wybierz opcję: ");
                    var input = Console.ReadLine();

                    // Handling the option selecting by the user
                    switch (input)
                    {
                        case "1":
                            AddOrRemoveEmployeeMenu addOrRemoveEmployeeMenu = new AddOrRemoveEmployeeMenu(employeeService);
                            addOrRemoveEmployeeMenu.ShowMenu();
                            break;
                        case "2":
                            FilterEmployeeMenu filterEmployeeMenu = new FilterEmployeeMenu(employeeService);
                            filterEmployeeMenu.ShowMenu();
                            break;
                        case "3":
                            SortEmployeeMenu sortEmployeeMenu = new SortEmployeeMenu(employeeService);
                            sortEmployeeMenu.ShowMenu();
                            break;
                        case "4":
                            return;
                        default:
                            Console.WriteLine("Nieznana opcja.");
                            break;
                    }

                    Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }

}
