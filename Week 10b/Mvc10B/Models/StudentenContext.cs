using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc10B
{
    public class StudentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder b) =>
            b.UseSqlite("Data Source=database.db");

        public DbSet<StudentDB> Studenten {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentDB>().ToTable("Student");
        }
    }

    public class StudentDB
    {
        [Key]
        public int StudentNummer {get; set;}
        [StringLength(25)]
        public string VoorNaam {get; set;}
        [StringLength(25)]
        public string EmailAdres {get; set;}
    }    
}