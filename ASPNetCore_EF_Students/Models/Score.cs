﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASPNetCore_EF_Students.Models
{
    public class Score
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Student? Student { get; set; }
        public Course? Course { get; set; }

        [Range(0, 20)]
        public int Points { get; set; }

    }
}