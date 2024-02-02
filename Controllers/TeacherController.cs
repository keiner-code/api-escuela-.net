using Curso.Services;
using Microsoft.AspNetCore.Mvc;
namespace Curso.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeacherController : ControllerBase
{
  readonly ITeacherService service;

  public TeacherController(ITeacherService Iservice)
  {
    service = Iservice;
  }

  [HttpGet]
  public IActionResult Get()
  {
    return Ok(service.Get());
  }

  [HttpPost]
  public IActionResult Post([FromBody] Teacher teacher)
  {
    try
    {
      if (teacher != null)
      {
        service.Save(teacher);
        return CreatedAtAction(nameof(Get), new { id = teacher.Id }, teacher);
      }
      else
      {
        return BadRequest("Por Favor Agrege Los Datos");
      }
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Error Interno en el servidor {ex}");
    }
  }

  [HttpPut("{id}")]
  public IActionResult Put(Guid id, [FromBody] Teacher changes)
  {
    try
    {
      if (changes != null)
      {
        service.Update(changes, id);
        return Ok(changes);
      }
      else
      {
        return BadRequest("Por Favor Agrege Los Datos");
      }
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Error Interno en el servidor {ex}");
    }
  }
  [HttpDelete("{id}")]
  public IActionResult Delete(Guid id)
  {
    service.Delete(id);
    return Ok(id);
  }

}