using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mvc10B.Models;
using Mvc10B.Controllers;

namespace Mvc10B.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult GeefDeStudent(int id)
        {           
            return View(StudentControllers.StudentController.Studenten[id]);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}