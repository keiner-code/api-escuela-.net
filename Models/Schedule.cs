using System.ComponentModel.DataAnnotations.Schema;

namespace Curso.Models;
public class Schedule
{

  public Guid Id { get; set; }
  [ForeignKey("CourseId")]
  public Guid CourseId { get; set; }
  public Guid TeacherId { get; set; }
  public string? Day { get; set; }
  public DateTime StartTime { get; set; }
  public DateTime EndTime { get; set; }
  public string? Section { get; set; }
  public virtual Course? Course { get; set; }
  public virtual Teacher? Teacher { get; set; }

  //pendiente la relacion con el docente y el aula

}