using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Week_12b.Data;
using Week_12b.Models;

namespace Week_12b.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext _context;


        public StudentController(StudentContext context)
        {
            _context = context;
        }

        // GET: Student
        
                public async Task<IActionResult> StudentenIndex(string sorteerVolgorde){
                    List<Student> Lijst = new List<Student>{
                    new Student {VoorNaam="Anna",AchterNaam ="Bell",HoogsteCijfer=4},
                    new Student {VoorNaam="Bart",AchterNaam = "van ses Berg",HoogsteCijfer=5},
                    new Student {VoorNaam="Truus",AchterNaam ="het Sapapparaat",HoogsteCijfer=3},
                    new Student {VoorNaam="Henkie",AchterNaam ="de roker",HoogsteCijfer=1},
                    new Student {VoorNaam="Betweter",AchterNaam ="je moeder",HoogsteCijfer=10}
                    };
            IQueryable<Student> lijst = _context.Students;
            switch (sorteerVolgorde)
            {
            case "aflopend": lijst = lijst.OrderByDescending(s => s.VoorNaam); break;
            default: lijst = lijst.OrderBy(s => s.VoorNaam); break;
            }
            return View(await lijst.ToListAsync());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VoorNaam,AchterNaam,Inschrijving,Opleiding,LeerJaar,HoogsteCijfer")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VoorNaam,AchterNaam,Inschrijving,Opleiding,LeerJaar,HoogsteCijfer")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
        public async Task<IActionResult> _student(){
        return View(await _context.Students.ToListAsync());
     }   
    }
}
