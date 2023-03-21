using System.ComponentModel.DataAnnotations;

namespace ASPNetCore_EF_Students.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}