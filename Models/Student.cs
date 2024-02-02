namespace Curso.Models;
public class Student
{
  public Guid Id {get; set;}
  public required string Name {get; set;}
  public required string LastName {get; set;}
  public required string SecondSurName {get; set;}
  public required int Age {get; set;}
  public required string Sexo {get; set;} 
  public virtual ICollection<Note>? Notes {get; set;}
  public virtual Enrollment? Enrollment {get; set;}
}

public enum Sexo {
  Masculino = 1,
  Femenino = 2,
  Otros = 3
}