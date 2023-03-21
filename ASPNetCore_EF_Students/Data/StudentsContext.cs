using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASPNetCore_EF_Students.Models;

namespace ASPNetCore_EF_Students.Data
{
    public class StudentsContext : DbContext
    {
        public StudentsContext(DbContextOptions<StudentsContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            int id = 1;

            modelBuilder.Entity<Course>()
                .HasData(
                    new Course { Id = id++, Name = ".NET Essentials" },
                    new Course { Id = id++, Name = ".NET Advanced" },
                    new Course { Id = id++, Name = "Programming Essentials" },
                    new Course { Id = id++, Name = "Programming Advanced" },
                    new Course { Id = id++, Name = "Data Essentials" },
                    new Course { Id = id, Name = "Data Advanced" }
                );

            id = 1;

            modelBuilder.Entity<Student>()
                .HasData(
                    new Student { Id = id++, Name = "Wim" },
                    new Student { Id = id++, Name = "Paul" },
                    new Student { Id = id++, Name = "Marvin" },
                    new Student { Id = id++, Name = "Michael" },
                    new Student { Id = id++, Name = "Amber" },
                    new Student { Id = id++, Name = "Anna" },
                    new Student { Id = id++, Name = "Belle" },
                    new Student { Id = id, Name = "Carrie" });

            modelBuilder.Entity<Score>()
                .HasData(
                    new Score { Id = 1, StudentId = 1, CourseId = 1, Grade = 20 },
                    new Score { Id = 2, StudentId = 1, CourseId = 2, Grade = 20 }
                );
        }

        public DbSet<Student> Students { get; set; } = default!;

        public DbSet<Course>? Courses { get; set; } = default!;

        public DbSet<Score>? Scores { get; set; } = default!;
    }
}
