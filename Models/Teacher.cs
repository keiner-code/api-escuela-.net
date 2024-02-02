using System.Text.Json.Serialization;
using Curso.Models;
public class Teacher
{
  public Guid Id {get; set;}
 /* [ForeignKey("ScheduleId")]
  public required Guid ScheduleId {get; set;} */
  public required string Name {get; set;}
  public required string LastName {get; set;}
  public required int Age {get; set;}
  public string? Gender {get; set;}
  public string? Address {get; set;}
  public required string Email {get; set;}
  public int? Phone {get; set;}
  [JsonIgnore]
  public virtual ICollection<Schedule>? Schedule {get; set;}
  


}
