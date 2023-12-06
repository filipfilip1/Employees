// Database context for Entity Framework Core
// SQLite as a database
// DbSet for employees and work addresses


using Microsoft.EntityFrameworkCore;
using Employees.Models;

namespace Employees.Data
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<WorkAddress> WorkAddresses { get; set; }

        // Configuring the connection to the database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=employee.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Implementation of inheritance from Employee model using discriminator
            modelBuilder.Entity<Employee>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<ManualWorker>("ManualWorker")
                .HasValue<OfficeEmployee>("OfficeEmployee")
                .HasValue<Trader>("Trader");

            // Definition of a one (WorkAddress) to Many (Employee) relationship
            modelBuilder.Entity<Employee>()
                .HasOne(emp => emp.WorkAddress)
                .WithMany(adr => adr.Employees)
                .HasForeignKey(emp => emp.WorkAddressId);
        }
    }
}
