using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Collections.Generic;
using Mvc10B.Models;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int HuidigStudentnummer, string NieuweNaam) {
            Student OudeStudent = null;
            Student NieuweStudent = null;

            foreach (Student student in studenten)
            {
                if(student.StudentNummer == HuidigStudentnummer)
                {
                    OudeStudent = student;
                    student.VoorNaam = NieuweNaam;
                    NieuweStudent = student;
                }
            }

            return RedirectToAction("IsEdited", NieuweStudent);
        }

        public IActionResult IsEdited(Student NieuweStudent)
        {
            return View(NieuweStudent);
        }

        public ActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string Naam) {
            int NieuwStudentNr = studenten.Count;
            NieuwStudentNr+=1;
            StudentDB s = new StudentDB() { StudentNummer = NieuwStudentNr, VoorNaam = Naam, EmailAdres = NieuwStudentNr + "@student.hhs.nl" };

            using(var ctx = new StudentContext())
            {
                ctx.Add(s);
                ctx.SaveChanges();
            }

            return RedirectToAction("IsCreated", s);
        }

        public IActionResult IsCreated(Student nieuweStudent) {
            return View(nieuweStudent);
        }
    }
}