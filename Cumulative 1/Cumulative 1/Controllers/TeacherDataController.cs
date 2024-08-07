using Cumulative_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class TeacherDataController : ControllerBase
{
    private readonly SchoolDbContext _context;

    public TeacherDataController(SchoolDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Teacher> GetTeachers()
    {
        return _context.Teachers.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Teacher> GetTeacher(int id)
    {
        var teacher = _context.Teachers.Find(id);

        if (teacher == null)
        {
            return NotFound();
        }

        return teacher;
    }

    [HttpPost]
    public ActionResult<Teacher> AddTeacher(Teacher teacher)
    {
        _context.Teachers.Add(teacher);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetTeacher), new { id = teacher.Id }, teacher);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTeacher(int id)
    {
        var teacher = _context.Teachers.Find(id);

        if (teacher == null)
        {
            return NotFound();
        }

        _context.Teachers.Remove(teacher);
        _context.SaveChanges();

        return NoContent();
    }
}
