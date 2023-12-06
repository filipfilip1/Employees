// Class Initializing the sample database for the use of the application
// Called every time the application is run 
// The Initialize method checks if the database already has data in the Employee table
// If the table is empty the database is populated with sample records

using Employees.Models;

namespace Employees.Data
{
    public static class DbSeed
    {
        public static void Initialize(EmployeeContext context)
        {
            context.Database.EnsureCreated();

            if (context.Employees.Any())
            {
                return;
            }

            
            var workAddresses = new List<WorkAddress>
            {
                new WorkAddress { City = "Gdańsk", Street = "Długa", BuildingNumber = "1", ApartmentNumber = "1" },
                new WorkAddress { City = "Sopot", Street = "Monte Cassino", BuildingNumber = "2", ApartmentNumber = "1" },
                new WorkAddress { City = "Gdynia", Street = "Świętojańska", BuildingNumber = "3", ApartmentNumber = "1" }
            };

            context.WorkAddresses.AddRange(workAddresses);
            context.SaveChanges();

            var traders = new List<Trader>
            {
                new Trader { Name = "Ewa", Surname = "Maj", Age = 45, Experience = 10, WorkAddressId = workAddresses[0].Id, Efficiency = Efficiency.High },
                new Trader { Name = "Marek", Surname = "Biały", Age = 38, Experience = 8, WorkAddressId = workAddresses[1].Id, Efficiency = Efficiency.Medium },
                new Trader { Name = "Kasia", Surname = "Kwiecień", Age = 40, Experience = 12, WorkAddressId = workAddresses[2].Id, Efficiency = Efficiency.Low },
                new Trader { Name = "Tomasz", Surname = "Nowak", Age = 50, Experience = 15, WorkAddressId = workAddresses[0].Id, Efficiency = Efficiency.High },
                new Trader { Name = "Olga", Surname = "Kowalska", Age = 35, Experience = 7, WorkAddressId = workAddresses[1].Id, Efficiency = Efficiency.Medium },
                new Trader { Name = "Adam", Surname = "Wiśniewski", Age = 42, Experience = 9, WorkAddressId = workAddresses[2].Id, Efficiency = Efficiency.Low },
                new Trader { Name = "Iwona", Surname = "Lewandowska", Age = 37, Experience = 6, WorkAddressId = workAddresses[0].Id, Efficiency = Efficiency.Medium }
            };

            var officeEmployees = new List<OfficeEmployee>
            {
                new OfficeEmployee { Name = "Anna", Surname = "Kowalska", Age = 28, Experience = 3, WorkAddressId = workAddresses[0].Id, Intellect = 110 },
                new OfficeEmployee { Name = "Piotr", Surname = "Zięba", Age = 32, Experience = 5, WorkAddressId = workAddresses[1].Id, Intellect = 105 },
                new OfficeEmployee { Name = "Ola", Surname = "Malinowska", Age = 26, Experience = 2, WorkAddressId = workAddresses[2].Id, Intellect = 100 },
                new OfficeEmployee { Name = "Marek", Surname = "Jabłoński", Age = 35, Experience = 6, WorkAddressId = workAddresses[0].Id, Intellect = 115 },
                new OfficeEmployee { Name = "Iga", Surname = "Wiśniewska", Age = 29, Experience = 4, WorkAddressId = workAddresses[1].Id, Intellect = 102 },
                new OfficeEmployee { Name = "Tomasz", Surname = "Dąb", Age = 31, Experience = 5, WorkAddressId = workAddresses[2].Id, Intellect = 108 },
                new OfficeEmployee { Name = "Karolina", Surname = "Lis", Age = 27, Experience = 3, WorkAddressId = workAddresses[0].Id, Intellect = 103 }
            };

            var manualWorkers = new List<ManualWorker>
            {
                new ManualWorker { Name = "Jakub", Surname = "Borowski", Age = 22, Experience = 1, WorkAddressId = workAddresses[0].Id, PhysicalStrength = 15 },
                new ManualWorker { Name = "Marcin", Surname = "Kozłowski", Age = 29, Experience = 4, WorkAddressId = workAddresses[1].Id, PhysicalStrength = 20 },
                new ManualWorker { Name = "Robert", Surname = "Więcek", Age = 35, Experience = 7, WorkAddressId = workAddresses[2].Id, PhysicalStrength = 18 },
                new ManualWorker { Name = "Kamil", Surname = "Nowak", Age = 40, Experience = 10, WorkAddressId = workAddresses[0].Id, PhysicalStrength = 25 },
                new ManualWorker { Name = "Bartek", Surname = "Majewski", Age = 27, Experience = 3, WorkAddressId = workAddresses[1].Id, PhysicalStrength = 17 },
                new ManualWorker { Name = "Paweł", Surname = "Kubiak", Age = 31, Experience = 5, WorkAddressId = workAddresses[2].Id, PhysicalStrength = 21 },
                new ManualWorker { Name = "Mikołaj", Surname = "Wójcik", Age = 24, Experience = 2, WorkAddressId = workAddresses[0].Id, PhysicalStrength = 16 }
            };





            context.Employees.AddRange(traders);
            context.Employees.AddRange(officeEmployees);
            context.Employees.AddRange(manualWorkers);

            context.SaveChanges();
        }
    }
}
