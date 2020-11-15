using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Collections.Generic;
using Mvc10B.Models;

namespace Mvc10B.Controllers
{
    public class StudentenController : Controller
    {
        private static List<Student> studenten = new List<Student>() 
        {
            new Student() {
                StudentNummer = 1, VoorNaam = "Scott", EmailAdres = "scott@student.hhs.nl"
            },
            new Student() {
                StudentNummer = 2, VoorNaam = "Dechaun", EmailAdres = "dechaun@student.hhs.nl"
            },
            new Student() {
                StudentNummer = 3, VoorNaam = "Alec", EmailAdres = "alec@student.hhs.nl"
            },
            new Student() {
                StudentNummer = 4, VoorNaam = "Joeri", EmailAdres = "joeri@student.hhs.nl"
            }
        };

        public IActionResult Aantal(string VoorNaam) {
            int result = 0;

            foreach(Student student in studenten) {
                if(student.VoorNaam == VoorNaam)
                    result++;
            }

            ViewBag.AantalStudenten = result;
            ViewBag.StudentNaam = VoorNaam;
            return View();
        }

        public IActionResult Email(int StudentNummer) {
            string result = "Het opgegeven studentnummer is niet in de lijst gevonden. Controleer het studentnummer en probeer het opnieuw!";

            foreach(Student student in studenten) {
                if(student.StudentNummer == StudentNummer) {
                    result = student.EmailAdres;
                }
            }

            ViewBag.EmailAdres = result;
            return View();
        }
    }
}