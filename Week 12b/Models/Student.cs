using System;

namespace Week_12B.Models
{
    public class Student
    {
        public int Id {get; set;}
        [Required]
        [StringLength(15)]
        public string VoorNaam {get; set;}
        [Required]
        [StringLength(20)]
        public string AchterNaam {get; set;}
        [Required]
        [Display(Name = "Geboortedatum")]
        public Date GeboorteDatum {get; set;}
        [Required]
        public string Opleiding {get; set;}
        [Required]
        [Range(1, 4)]
        public int LeerJaar {get; set;}
        [Range(0, 10)]
        public double HoogsteCijfer {get; set;}

        public List<Student> Vrienden {get; set;}
    }
}