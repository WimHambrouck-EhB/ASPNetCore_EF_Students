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
        public StudentsContext (DbContextOptions<StudentsContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; } = default!;

        public DbSet<Course>? Course { get; set; } = default!;

        public DbSet<Score>? Score { get; set; } = default!;
    }
}
