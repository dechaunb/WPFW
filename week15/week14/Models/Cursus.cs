using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace week14.Models
{
    public class Cursus{
        public int cursusId {get;set;}
        public string cursusNaam {get;set;}

        public ICollection<Student> student{get; set;}
    }
}