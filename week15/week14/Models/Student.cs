using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace week14.Models
{
    public class Student{
        public int studentId {get;set;}
        public string studentNaam {get;set;}
        public int lengte {get; set;}
        public int cursusId {get; set;}
        public Cursus cursus {get; set;}
    }
}