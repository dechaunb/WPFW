using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using week14.Data;
using week14.Models;


namespace week14.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext _context;

        public StudentController(StudentContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> StudentIndex(string filter,string sorterenOp)
        {   
            var studentContext = _context.Student.Include(s => s.cursus);
            List<Student> studentenList = studentContext.ToList();
            List<Student> query = new List<Student>();
            
            if(filter!=null){
                foreach (var student in studentenList.Where(s=>(s.studentNaam.Contains(filter))||(s.studentId.ToString().Contains(filter))||(s.lengte.ToString().Contains(filter))))
                {
                     query.Add(student);
                }
                studentenList = query;
            }
            if(query.Count()==0){
                query=studentenList;
            }
            if(sorterenOp!=null){
                if(sorterenOp.Equals("id")){
                    query = query.OrderBy(s=>s.studentId).ToList();
                }else if(sorterenOp.Equals("naam")){
                    query = query.OrderBy(s=>s.studentNaam).ToList();
                }else if(sorterenOp.Equals("lengte")){
                    query = query.OrderBy(s=>s.lengte).ToList();
                }else if(sorterenOp.Equals("cursus")){
                    query = query.OrderBy(s=>s.cursusId).ToList();
                }
            }
            return View(query);
        }

        // GET: Student
        /*
        public async Task<IActionResult> StudentIndex()
        {
            var studentContext = _context.Student.Include(s => s.cursus);
            return View(await studentContext.ToListAsync());
        }
        */

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.cursus)
                .FirstOrDefaultAsync(m => m.studentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            ViewData["cursusId"] = new SelectList(_context.Set<Cursus>(), "cursusId", "cursusId");
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("studentId,studentNaam,lengte,cursusId")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["cursusId"] = new SelectList(_context.Set<Cursus>(), "cursusId", "cursusId", student.cursusId);
            return View(student);
        }

        public IActionResult CreateCursus()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCursus([Bind("cursusId,cursusNaam")] Cursus cursus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cursus);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["cursusId"] = new SelectList(_context.Set<Cursus>(), "cursusId", "cursusId", student.cursusId);
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("studentId,studentNaam,lengte,cursusId")] Student student)
        {
            if (id != student.studentId)
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
                    if (!StudentExists(student.studentId))
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
            ViewData["cursusId"] = new SelectList(_context.Set<Cursus>(), "cursusId", "cursusId", student.cursusId);
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.cursus)
                .FirstOrDefaultAsync(m => m.studentId == id);
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
            var student = await _context.Student.FindAsync(id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.studentId == id);
        }
    }
}
