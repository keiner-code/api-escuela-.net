using Curso.Models;
using Curso.Services;
using Microsoft.AspNetCore.Mvc;
namespace Curso.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScheduleController : ControllerBase
{
  IScheduleService scheduleService;
  CourseContext dbcontext;
  public ScheduleController(IScheduleService service, CourseContext db)
  {
    scheduleService = service;
    dbcontext = db;
  }

  [HttpGet]
  public IActionResult Get()
  {
    return Ok(scheduleService.GetAll());
  }

  [HttpPost]
  public IActionResult Post([FromBody] Schedule schedule)
  {
    if (schedule == null) return BadRequest("El objeto horario no puede ser nulo.");
    if (string.IsNullOrWhiteSpace(schedule.Day)) return BadRequest("El dia del curso no puede estar vacío.");
    try
    {
      scheduleService.Save(schedule);
      return CreatedAtAction(nameof(Get), new { id = schedule.Id }, schedule);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Error interno del servidor al guardar el curso. {ex}");
    }
  }

  [HttpPut("{id}")]
  public IActionResult Put(Guid id, [FromBody] Schedule schedule)
  {
    if (schedule == null) return BadRequest("El objeto Schedule no puede ser nulo.");
    if (string.IsNullOrWhiteSpace(schedule.Day)) return BadRequest("El dia del curso no puede estar vacío.");
    try
    {
      scheduleService.Update(id, schedule);
      return Ok(schedule);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Error interno del servidor al guardar el curso.{ex}");
    }
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(Guid id)
  {
    scheduleService.Delete(id);
    return Ok(id);
  }
}