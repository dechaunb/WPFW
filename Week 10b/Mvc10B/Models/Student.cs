using System;
using System.ComponentModel.DataAnnotations;

namespace Mvc10B.Models 
{
    public class Student 
    {
        public int StudentNummer {get; set;}
        public string VoorNaam {get; set;}
        public string EmailAdres {get; set;}
    }
}