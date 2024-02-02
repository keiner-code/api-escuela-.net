using System.ComponentModel.DataAnnotations.Schema;
namespace Curso.Models;
public class Note
{
  public Guid Id { get; set; }
  [ForeignKey("CourseId")]
  public Guid CourseId { get; set; }
  [ForeignKey("EstudentId")]
  public Guid EstudentId {get; set;}
  public int Notes { get; set; }
  public int Term { get; set; }
  public string? Description { get; set; }
  public virtual Course? Course { get; set; }
  public virtual Student? Student {get; set;}
}