using Cumulative_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class TeacherController : Controller
{
    private SchoolDbContext _context;

    public TeacherController(SchoolDbContext context)
    {
        _context = context;
    }

    public IActionResult List()
    {
        var teachers = _context.Teachers.ToList();
        return View(teachers);
    }

    public IActionResult Show(int id)
    {
        var teacher = _context.Teachers.Find(id);

        if (teacher == null)
        {
            return NotFound();
        }

        return View(teacher);
    }

    [HttpGet]
    public IActionResult New()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Teacher teacher)
    {
        if (ModelState.IsValid)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
        return View("New", teacher);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var teacher = _context.Teachers.Find(id);

        if (teacher != null)
        {
            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
        }

        return RedirectToAction("List");
    }
}
