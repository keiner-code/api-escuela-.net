using Curso.Models;

namespace Curso.Services;
public class EnrollmentService: IEnrollmentService
{
  public CourseContext context;
  public EnrollmentService(CourseContext db)
  {
    context = db;
  }
  public IEnumerable<Enrollment> GetAll(){
    return context.Enrollments;
  }
  public async Task Save(Enrollment enrollment){
    context.Add(enrollment);
    await context.SaveChangesAsync();
  }
  public async Task Update(Enrollment changes, Guid id){
    var enrollment = context.Enrollments.Find(id);
    if(enrollment != null){
      enrollment.Id = changes.Id; 
      enrollment.IdStudent = changes.IdStudent;
      enrollment.Date = changes.Date; 
      enrollment.Amount = changes.Amount; 
      enrollment.Grade = changes.Grade;
      await context.SaveChangesAsync();
    }
  }
  public async Task Delete(Guid id){
    var enrollment = context.Enrollments.Find(id);
    if(enrollment != null){
      context.Remove(enrollment);
      await context.SaveChangesAsync();
    }
  }
}
public interface IEnrollmentService
{
  IEnumerable<Enrollment> GetAll();
  Task Save(Enrollment enrollment);
  Task Update(Enrollment changes, Guid id);
  Task Delete(Guid id);
}