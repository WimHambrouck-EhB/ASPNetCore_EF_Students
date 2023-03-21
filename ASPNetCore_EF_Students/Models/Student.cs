using System.ComponentModel.DataAnnotations;

namespace ASPNetCore_EF_Students.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public ICollection<Score>? Scores { get; set; }
    }
}
