using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data;
using SchoolSystem.Models;

namespace SchoolSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly SchoolDbContext _context;

        public StudentController(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ShowAll()
        {
            var students = await _context.Students
                .AsNoTracking()
                .Include(s => s.Department)
                .ToListAsync();

            return View(students);
        }

        public async Task<IActionResult> ShowDetails(int id)
        {
            var student = await _context.Students
                .AsNoTracking()
                .Include(s => s.Department)
                .Include(s => s.StuCrsRes)
                    .ThenInclude(sc => sc.Course)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
                return NotFound();

            return View(student);
        }
    }
}
