// Repository interface for the Employee entity
// Defines basic CRUD operations

using Employees.Models;

namespace Employees.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int Id);
        bool Add(Employee employee); 
        bool RemoveById(int Id);

    }
}
