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
                StudentNummer = 1, VoorNaam = "Scott", EmailAdres = "1@student.hhs.nl"
            },
            new Student() {
                StudentNummer = 2, VoorNaam = "Dechaun", EmailAdres = "2@student.hhs.nl"
            },
            new Student() {
                StudentNummer = 3, VoorNaam = "Alec", EmailAdres = "3@student.hhs.nl"
            },
            new Student() {
                StudentNummer = 4, VoorNaam = "Joeri", EmailAdres = "4@student.hhs.nl"
            }
        };

        public IActionResult Aantal(string VoorNaam) 
        {
            int result = 0;

            foreach(Student student in studenten) 
            {
                if(student.VoorNaam == VoorNaam)
                    result++;
            }

            ViewBag.AantalStudenten = result;
            ViewBag.StudentNaam = VoorNaam;
            return View();
        }

        public IActionResult Email(int StudentNummer) 
        {
            string result = "Het opgegeven studentnummer is niet in de lijst gevonden. Controleer het studentnummer en probeer het opnieuw!";

            foreach(Student student in studenten) 
            {
                if(student.StudentNummer == StudentNummer) 
                    result = student.EmailAdres;
            }

            ViewBag.EmailAdres = result;
            return View();
        }

        public IActionResult ZoekStudenten(string VoorLetter)
        {
            List<Student> result = new List<Student>();

            foreach (Student student in studenten)
            {
                if(student.VoorNaam.Substring(0, 1) == VoorLetter)
                    result.Add(student);
            }

            ViewBag.StudentenMetVoorletter = result;
            ViewBag.VoorLetter = VoorLetter;
            return View();
        }

        public ActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string Naam) {
            int NieuwStudentNr = studenten.Count;
            NieuwStudentNr+=1;
            Student s = new Student() { StudentNummer = NieuwStudentNr, VoorNaam = Naam, EmailAdres = NieuwStudentNr + "@student.hhs.nl" };
            studenten.Add(s);
            
            return RedirectToAction("IsCreated", s);
        }

        public IActionResult IsCreated(Student nieuweStudent) {
            return View(nieuweStudent);
        }
    }
}