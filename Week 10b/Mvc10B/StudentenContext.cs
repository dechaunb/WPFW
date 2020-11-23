using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc10B
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Studenten {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
        }
    }

    public class Student
    {
        [Key]
        public int StudentNummer {get; set;}
        [StringLength(25)]
        public string VoorNaam {get; set;}
        [StringLength(25)]
        public string EmailAdres {get; set;}
    }

    
}