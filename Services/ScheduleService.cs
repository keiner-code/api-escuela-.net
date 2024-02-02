using Curso.Models;
using Microsoft.EntityFrameworkCore;
namespace Curso.Services;

public class ScheduleService : IScheduleService
{
  public CourseContext context;

  public ScheduleService(CourseContext db)
  {
    context = db;
  }

  public IEnumerable<Schedule> GetAll()
  {
    return context.Schedules
    .Include(c => c.Course)
    .Select(s => new Schedule()
    {
      Id = s.Id,
      Day = s.Day,
      StartTime = s.StartTime,
      Course = s.Course
    })
    .ToList();
  }

  public async Task Save(Schedule schedule)
  {
    context.Add(schedule);
    await context.SaveChangesAsync();
  }

  public async Task Update(Guid id, Schedule schedule)
  {
    var IsSchedule = context.Schedules.Find(id);

    if (IsSchedule != null)
    {
      IsSchedule.Id = schedule.Id;
      IsSchedule.Day = schedule.Day;
      IsSchedule.StartTime = schedule.StartTime;
      IsSchedule.EndTime = schedule.EndTime;
      IsSchedule.Section = schedule.Section;
      await context.SaveChangesAsync();
      /* public Guid CourseId {get; set;}*/
    }
  }

  public async Task Delete(Guid id)
  {
    var IsSchedule = context.Schedules.Find(id);
    if (IsSchedule != null)
    {
      context.Remove(IsSchedule);
      await context.SaveChangesAsync();
    }
  }

}

public interface IScheduleService
{
  IEnumerable<Schedule> GetAll();
  Task Save(Schedule schedule);
  Task Update(Guid id, Schedule schedule);
  Task Delete(Guid id);
}

