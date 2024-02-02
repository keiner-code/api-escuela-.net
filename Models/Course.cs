using System.Text.Json.Serialization;
namespace Curso.Models;
public class Course
{
  public Guid Id { get; set; }
  public required string Name { get; set; }

  [JsonIgnore]
  public virtual ICollection<Schedule>? Schedules { get; set; }
  [JsonIgnore]
  public virtual ICollection<Note>? Notes {get; set;}
}