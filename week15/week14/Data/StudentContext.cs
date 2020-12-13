using Microsoft.EntityFrameworkCore;
using week14.Models;

namespace week14.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext (DbContextOptions<StudentContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
    }
}