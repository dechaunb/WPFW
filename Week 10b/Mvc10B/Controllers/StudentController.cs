using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mvc10B.Models;

namespace Mvc10B.StudentControllers
{
    public class StudentController : Controller
    {
        private static List<Student> StudentenList = null;

        public static List<Student> Studenten{
            get
            {
                //ist<Student> result;
                if(StudentenList == null)
                {
                    StudentenList = new List<Student>();
                    Studenten.Add(new Student{StudentId=0,Achternaam="sick"});
                    Studenten.Add(new Student{StudentId=1,Achternaam="sick"});
                    Studenten.Add(new Student{StudentId=2,Achternaam="bart"});
                    Studenten.Add(new Student{StudentId=3,Achternaam="henk"});
                    }
                    return StudentenList;
                }
            } 
        private static Student zoek(int id)
        {
            Student result = null;
            foreach (Student student in Studenten){
                if (id == student.StudentId)
                { 
                    result = student;
                }
            }
            return result;
        }
        public ViewResult ToonStudent(int id){
            Student student = zoek(id);
            return View(student);
        }
        public ViewResult Aantal(string voornaam){
            int aantal = 0;
            foreach (Student student in Studenten){
                if((voornaam=student.voornaam))
                    aantal++;
            }
        return "De naam "+voornaam+" komt "+aantal+" keer voor in de lijst";
        }
    }
}