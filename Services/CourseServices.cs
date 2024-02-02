using Curso.Models;
namespace Curso.Services;
public class CourseService : ICourseService
{
  public CourseContext context;

  public CourseService(CourseContext dbcontext)
  {
    context = dbcontext;
  }

  public IEnumerable<Course> Get()
  {
    return context.Courses;
  }

  public async Task Save(Course course)
  {
    context.Add(course);
    await context.SaveChangesAsync();
  }

  public async Task Update(Guid id, Course course)
  {
    var IsCourse = context.Courses.Find(id);
    if (IsCourse != null)
    {
      IsCourse.Id = course.Id;
      IsCourse.Name = course.Name;
      await context.SaveChangesAsync();
    }
  }

  public async Task Delete(Guid id)
  {
    var IsCourse = context.Courses.Find(id);
    if (IsCourse != null)
    {
      context.Remove(IsCourse);
      await context.SaveChangesAsync();
    }
  }
}

public interface ICourseService
{
  IEnumerable<Course> Get();
  Task Save(Course course);
  Task Update(Guid id, Course course);
  Task Delete(Guid id);
}