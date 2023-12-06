// Class representing the work address of a specific employee

using System.ComponentModel.DataAnnotations;


namespace Employees.Models
{
    public class WorkAddress
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Street { get; set; }

        [Required]
        [StringLength(50)]
        public string BuildingNumber { get; set; }
        
        public string ApartmentNumber { get; set; }

        [Required]
        [StringLength (50)]
        public string City { get; set; }

        // collection navigations for Employee
        // represents many in a one-to-many relationship
        public ICollection<Employee> Employees { get; set; }

        // Initializes the Employees property as a new HashSet
        // Creating a constructor protects against an error if you try to access the Employees property right after creating the Address
        public WorkAddress()
        {
            Employees = new HashSet<Employee>();
        }

    }
}
