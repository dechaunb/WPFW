using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Collections.Generic;
using Mvc10B.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Mvc10B.Controllers
{
    public class StudentenController : Controller
    {
        private static List<StudentDB> studenten = new List<StudentDB>();

        public IActionResult Aantal(string VoorNaam) 
        {
            int result = 0;

            using(var ctx = new StudentContext())
            {
                result = ctx.Studenten.Where(std => std.VoorNaam == VoorNaam).Count();
            }

            ViewBag.AantalStudenten = result;
            ViewBag.StudentNaam = VoorNaam;
            return View();
        }

        public IActionResult Email(int StudentNummer) 
        {
            string result = "Het opgegeven studentnummer is niet in de lijst gevonden. Controleer het studentnummer en probeer het opnieuw!";

            using(var ctx = new StudentContext())
            {
                result = ctx.Studenten.Where(std => std.StudentNummer == StudentNummer).Select(std => std.EmailAdres).SingleOrDefault();
            }

            ViewBag.EmailAdres = result;
            return View();
        }

        public IActionResult ZoekStudenten(string VoorLetter)
        {
            using(var ctx = new StudentContext())
            {
                var ZoekStudent = ctx.Studenten.Where(std => std.VoorNaam.StartsWith(VoorLetter)).ToList();
                
                if(ZoekStudent != null)
                {
                    ViewBag.VoorLetter = VoorLetter;
                    ViewBag.StudentenMetVoorletter = ZoekStudent;
                }
            }

            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int HuidigStudentnummer, string NieuweNaam, StudentContext context) {
            StudentDB NieuweStudent = null;

            using(var ctx = new StudentContext())
            {
                var OudeStudent = ctx.Studenten.FirstOrDefault(std => std.StudentNummer == HuidigStudentnummer);

                if(OudeStudent != null) {
                    OudeStudent.VoorNaam = NieuweNaam;
                    ctx.SaveChanges();
                    NieuweStudent = OudeStudent;
                }
            }


            return RedirectToAction("IsEdited", NieuweStudent);
        }

        public IActionResult IsEdited(StudentDB NieuweStudent)
        {
            return View(NieuweStudent);
        }

        public ActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string Naam, StudentContext context) {
            var AantalStudenten = context.Studenten.Count();

            int NieuwStudentNr = AantalStudenten + 1;
            StudentDB s = new StudentDB() {VoorNaam = Naam, EmailAdres = NieuwStudentNr + "@student.hhs.nl" };

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