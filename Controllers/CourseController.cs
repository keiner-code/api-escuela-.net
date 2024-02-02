using Curso.Models;
using Curso.Services;
using Microsoft.AspNetCore.Mvc;
namespace Curso.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
  ICourseService courseService;
  CourseContext dbcontext;

  public CourseController(ICourseService service, CourseContext db)
  {
    courseService = service;
    dbcontext = db;
  }

  [HttpGet]
  public IActionResult Get()
  {
    return Ok(courseService.Get());
  }

  [HttpPost]
  public IActionResult Post([FromBody] Course course)
  {
    if (course == null) return BadRequest("El objeto Course no puede ser nulo.");
    if (string.IsNullOrWhiteSpace(course.Name)) return BadRequest("El nombre del curso no puede estar vacío.");
    try
    {
      courseService.Save(course);
      return CreatedAtAction(nameof(Get), new { id = course.Id }, course);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Error interno del servidor al guardar el curso. {ex}");
    }
  }


  [HttpPut("{id}")]
  public IActionResult Put(Guid id, [FromBody] Course course)
  {
    if (course == null) return BadRequest("El objeto Course no puede ser nulo.");
    if (string.IsNullOrWhiteSpace(course.Name)) return BadRequest("El nombre del curso no puede estar vacío.");
    try
    {
      courseService.Update(id, course);
      return Ok(course);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Error interno del servidor al guardar el curso.{ex}");
    }
  }

  [HttpDelete("{id}")]

  public IActionResult Delete(Guid id)
  {
    courseService.Delete(id);
    return Ok(id);
  }

  [HttpGet]
  [Route("createdb")]
  public IActionResult createDatabase()
  {
    dbcontext.Database.EnsureCreated();
    return Ok();
  }
}