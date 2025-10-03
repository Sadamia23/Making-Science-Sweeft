using Microsoft.EntityFrameworkCore;
using SweeftAssignment.Task_7.Database;
using SweeftAssignment.Task_7.Entities;

namespace SweeftAssignment.Task_7;

public class SchoolService(AppDbContext _context)
{
    public async Task<Teacher[]> GetAllTeachersByStudentAsync(string studentName)
    {
        var teachers = await _context.Teachers
            .Where(t => t.TeacherPupils
                .Any(tp => tp.Pupil.FirstName.ToLower() == studentName.ToLower()))
            .ToArrayAsync();

        return teachers;
    }
}