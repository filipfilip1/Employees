// Repository for the employee entity

using Employees.Models;
using Employees.Data;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Employees.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        public Employee GetById(int Id)
        {
            return _context.Employees.Find(Id);
        }

        public bool RemoveById(int Id)
        {
            try
            {
                var employee = _context.Employees.Find(Id);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error when updating Database - {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error - {ex.Message}");
                return false;
            }
        }

        public bool Add(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return true;
            }
            catch (DbException ex)
            {
                Console.WriteLine($"Error when updating Database - {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error - {ex.Message}");
                return false;
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            // Loading the associated WorkAddress with the Employee model
            return _context.Employees.Include(emp => emp.WorkAddress).ToList();
        }

    }
}
