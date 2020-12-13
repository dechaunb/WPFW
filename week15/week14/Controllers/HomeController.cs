using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using week14.Models;

namespace week14.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Studenten(string filter,string sorterenOp)
        {
            List<Student> studenten = new List<Student>();
            List<Student> query = new List<Student>();
            Student Alec = new Student {studentId=1 , studentNaam= "Alec",lengte=189,cursusId=4};
            Student Joeri = new Student {studentId=2 , studentNaam= "Joeri",lengte=181,cursusId=2};
            Student Dechaun = new Student {studentId=3 , studentNaam= "Dechaun",lengte=185,cursusId=2};
            Student Scott = new Student {studentId=4 , studentNaam= "Scott",lengte=365,cursusId=4};
            studenten.Add(Alec);
            studenten.Add(Joeri);
            studenten.Add(Dechaun);
            studenten.Add(Scott);
            query = studenten;
            if(sorterenOp!=null){
                if(sorterenOp.Equals("id")){
                    query = studenten.OrderBy(s=>s.studentId).ToList();
                }else if(sorterenOp.Equals("naam")){
                    query = studenten.OrderBy(s=>s.studentNaam).ToList();
                }else if(sorterenOp.Equals("lengte")){
                    query = studenten.OrderByDescending(s=>s.lengte).ToList();
                }else if(sorterenOp.Equals("cursus")){
                    query = studenten.OrderByDescending(s=>s.cursusId).ToList();
                }
            }
            return View(query);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
