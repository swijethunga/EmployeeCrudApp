using System.ComponentModel.DataAnnotations;

namespace EmployeeCrudApp.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string departmentCode { get; set; } = string.Empty;
        [Required]
        public string departmentName { get; set; } = string.Empty;
        
    }
}
