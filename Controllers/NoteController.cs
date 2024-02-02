using Curso.Models;
using Microsoft.AspNetCore.Mvc;
namespace Curso.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NoteController : ControllerBase
{
  public INoteService service;
  public NoteController(INoteService se)
  {
    service = se;
  }

  [HttpGet]
  public IActionResult Get()
  {
    return Ok(service.GetAll());
  }
  [HttpPost]
  public IActionResult Post([FromBody] Note note)
  {
    try
    {
      if (note != null)
      {
        if (note.Notes != 0 && note.Term != 0)
        {
          service.Save(note);
          return CreatedAtAction(nameof(Get), new { Id = note.Id }, note);
        }else{
          return BadRequest("Hay Valores Que Son Obligatorios");
        }
      }
      else
      {
        return BadRequest("Por Favor Ingrese Datos En Los Campos");
      }
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Error interno del servidor al guardar el curso. {ex}");
    }
  }
  [HttpPut("{id}")]
  public IActionResult Put(Guid id, [FromBody] Note note)
  {
    try
    {
      if (note != null)
      {
        if (note.Notes == 0 && note.Term == 0)
        {
          service.Update(note, id);
          return Ok($"Update: {id}");
        }
        return BadRequest("Hay Valores Que Son Obligatorios");
      }
      else
      {
        return BadRequest("Por Favor Ingrese Datos En Los Campos");
      }
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Error interno del servidor al guardar el curso. {ex}");
    }
  }
  [HttpDelete("{id}")]
  public IActionResult Delete(Guid id)
  {
    service.Delete(id);
    return NoContent();
  }
}