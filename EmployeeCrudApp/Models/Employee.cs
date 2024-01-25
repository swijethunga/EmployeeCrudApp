using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeCrudApp.Models
{
    public class Employee
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        public string firstName { get; set; } = string.Empty;
        [Required]
        public string lastName { get; set; } = string.Empty;
        [Required]
        public string email { get; set; } = string.Empty;
        [Required]
        public DateTime dob  { get; set; }

        [Required] public int age { get; set; }
        [Required]
        public float salary { get; set; }
        [Required]
        public string department { get; set; } = string.Empty;
    }
}
