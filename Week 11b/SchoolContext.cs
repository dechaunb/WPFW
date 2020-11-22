using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Week_11b
{
    public class SchoolContext : DbContext
    {
        public DbSet<Docent> Docenten {get; set;}
        public DbSet<Student> Studenten {get; set;}
        public DbSet<Vak> Vakken {get; set;}
        public DbSet<Inschrijving> Inschrijvingen {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inschrijving>()
                .HasKey(i => new {i.StudentId, i.VakId, i.Semester});
        }
    }

    public class Persoon
    {
        [Key]
        public int Id {get; set;}
        public string VoorNaam {get; set;}
        public string AchterNaam {get; set;}
        public string MailAdres {get; set;}
    }

    public class Docent : Persoon 
    {
        public int MaandSalaris {get; set;}
        public Vak Vak {get; set;}
        
    }

    public class Student : Persoon 
    {
        public int LeerJaar {get; set;}
    }

    public class Vak
    {
        [Key]
        public int Id {get; set;}
        public int StudiePunten {get; set;}
        public string Beschrijving {get; set;}
        public int DocentId {get; set;}
        public Docent Docent {get; set;}
    }

    public class Inschrijving {
        public int StudentId {get; set;}
        public Student Student {get; set;}
        public int VakId {get; set;}
        public Vak Vak;
        public int Semester {get; set;}
    }
}