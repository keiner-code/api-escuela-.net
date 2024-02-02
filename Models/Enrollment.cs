using System.ComponentModel.DataAnnotations.Schema;

namespace Curso.Models;
public class Enrollment //matricula
{
  public Guid Id {get; set;}
  [ForeignKey("IdStudent")]
  public Guid IdStudent {get; set;}
  public string? Date {get; set;}
  public double? Amount {get; set;}
  public string? Grade {get; set;}
  public virtual Student? Student {get; set;}
}