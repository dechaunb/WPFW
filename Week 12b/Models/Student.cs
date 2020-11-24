using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Inschrijfdatum")]
        public DateTime Inschrijving {get; set;}
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