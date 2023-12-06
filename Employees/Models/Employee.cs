// An abstract class containing common characteristics for all employees

using System.ComponentModel.DataAnnotations;

namespace Employees.Models
{
    public abstract class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Surname { get; set; }
        
        [Required]
        [Range(18, 100)]
        public int Age { get; set; }

        [Required]
        [Range(0, 100)]
        public int Experience { get; set; }

        [Required]
        // Foreign Key for WorkAddress
        public int WorkAddressId { get; set; }

        // Reference navigations for WorkAddress
        // Represents one in a one-to-many relationship
        public WorkAddress WorkAddress { get; set; }
    }
}
