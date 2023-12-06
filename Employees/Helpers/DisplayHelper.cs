// Helper class containing methods to display data in the console
// Displays data passed to methods about employees

using Employees.Models;

namespace Employees.Helpers
{
    public class DisplayHelper
    {
        public static void DisplayEmployee(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"ID: {employee.Id}, {employee.Name} {employee.Surname} - Miasto: {employee.WorkAddress?.City ?? "Brak miasta"} - Wiek: {employee.Age}, Doświadczenie: {employee.Experience}");
            }
        }

        public static void DisplayDictionary<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
        {
            foreach (var item in dictionary)
            {
                Console.WriteLine($"Klucz: {item.Key}, Wartość: {item.Value}");
            }
        }
    }
}
