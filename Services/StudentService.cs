using Curso.Models;

namespace Curso.Services;

public class StudentService: IStudentService
{
  public CourseContext context;
  public StudentService(CourseContext ct){
    context = ct;
  }
  public IEnumerable<Student> GetAll(){
    return context.Students;
  }
  public async Task Save(Student student){
    context.Add(student);
    await context.SaveChangesAsync();
  }
  public async Task Update(Student Changes, Guid id){
    var student = context.Students.Find(id);
    if(student != null){
      student.Id = Changes.Id;
      student.Name = Changes.Name;
      student.LastName = Changes.LastName;
      student.SecondSurName = Changes.SecondSurName;
      student.Age = Changes.Age;
      student.Sexo = student.Sexo;
      await context.SaveChangesAsync();
    }
  }
  public async Task Delete(Guid id){
    context.Remove(id);
    await context.SaveChangesAsync();
  }
}
public interface IStudentService
{
  IEnumerable<Student> GetAll();
  Task Save(Student studen);
  Task Update(Student Changes, Guid id);
  Task Delete(Guid id);
}