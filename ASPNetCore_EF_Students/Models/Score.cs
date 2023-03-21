using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASPNetCore_EF_Students.Models
{
    public class Score
    {
        public int Id { get; set; }

        [Display(Name = "Student")]
        public int StudentId { get; set; }
        
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        public Student? Student { get; set; }
        public Course? Course { get; set; }

        [Range(0, 20)]
        public int Grade { get; set; }

        [NotMapped]
        [DisplayFormat(DataFormatString = "{0}%")]
        public int GradeAsPercentage => Grade * 5;

    }
}