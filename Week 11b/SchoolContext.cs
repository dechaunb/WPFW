using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Week_11b
{
    public class SchoolContext : DbContext
    {
        public DbSet<Docent> Docenten {get; set;}
        public DbSet<Student> Studenten {get; set;}
        public DbSet<Vak> Vakken {get; set;}
        public DbSet<Inschrijving> Inschrijvingen {get; set;}
        public DbSet<Resultaat> Resultaten {get; set;}

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
        [StringLength(15)]
        public string VoorNaam {get; set;}
        [StringLength(25)]
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
    [Table("SchoolVak")]
    public class Vak
    {
        [Key]
        public int Id {get; set;}
        [Column("SP")]
        public int StudiePunten {get; set;}
        public string Beschrijving {get; set;}
        public int DocentId {get; set;}
        [NotMapped]
        public Docent Docent {get; set;}
    }

    public class Inschrijving {
        public int StudentId {get; set;}
        [NotMapped]
        public Student Student {get; set;}
        public int VakId {get; set;}
        [NotMapped]
        public Vak Vak {get; set;}
        public int Semester {get; set;}
    }

    public class Resultaat
    {
        [Key]
        public int Id {get; set;}
        public double Cijfer {get; set;}
        public int InschrijvingId {get; set;}
        [NotMapped]
        public Inschrijving Inschrijving {get; set;}
    }
}