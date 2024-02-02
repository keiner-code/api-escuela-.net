using Curso.Models;
using Microsoft.EntityFrameworkCore;

namespace Curso.Services;
public class TeacherService : ITeacherService
{
  CourseContext context;
  public TeacherService(CourseContext db)
  {
    context = db;
  }

  public IEnumerable<Teacher> Get()
  {
     var teachers = context.Teachers
        .Include(t => t.Schedule)
        .ToList();

    return teachers.Select(teacher =>
    {
        foreach (var schedule in teacher.Schedule ?? Enumerable.Empty<Schedule>())
        {
            schedule.Teacher = null;
        }
        return teacher;
    });
  }
  public async Task Save(Teacher teacher)
  {
    context.Add(teacher);
    await context.SaveChangesAsync();
  }
  public async Task Update(Teacher changes, Guid id)
  {
    var teacher = context.Teachers.Find(id);
    if (teacher != null)
    {
      teacher.Name = changes.Name;
      teacher.LastName = changes.LastName;
      teacher.Age = changes.Age;
      teacher.Gender = changes.Gender;
      teacher.Address = changes.Address;
      teacher.Email = changes.Email;
      teacher.Phone = changes.Phone;
      await context.SaveChangesAsync();
    }
  }
  public async Task Delete(Guid id)
  {
    var teacher = context.Teachers.Find(id);
    if (teacher != null)
    {
      context.Remove(teacher);
      await context.SaveChangesAsync();
    }
  }
}
public interface ITeacherService
{
  IEnumerable<Teacher> Get();
  Task Save(Teacher teacher);
  Task Update(Teacher changes, Guid id);
  Task Delete(Guid id);
}