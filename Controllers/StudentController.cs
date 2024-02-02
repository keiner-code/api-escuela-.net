using Curso.Models;
using Curso.Services;
using Microsoft.AspNetCore.Mvc;
namespace Curso.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController(IStudentService Is) : ControllerBase
{
  public IStudentService service = Is;

  [HttpGet]
  public IActionResult Get()
  {
    return Ok(service.GetAll());
  }

  [HttpPost]
  public IActionResult Post([FromBody] Student student)
  {
    Console.WriteLine($"{student.Name},{student.LastName}, {student.SecondSurName},{student.Age}, {student.Sexo}");
    try
    {
      if (student != null)
      {
        service.Save(student);
        return CreatedAtAction(nameof(Get), new { Id = student.Id }, student);
      }
      else
      {
        return BadRequest("Hay Valores Que Son Obligatorios");
      }
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Error interno del servidor al guardar el curso. {ex}");
    }
  }

  [HttpPut("{id}")]
  public IActionResult Put([FromBody] Student student, Guid id)
  {
    try
    {
      if (student != null)
      {
        if (string.IsNullOrWhiteSpace(student.Name)
            && string.IsNullOrWhiteSpace(student.LastName)
            && string.IsNullOrWhiteSpace(student.SecondSurName)
            && student.Age != 0
            && string.IsNullOrWhiteSpace(student.Sexo.ToString())
            )
        {
          service.Update(student, id);
          return Ok(student);
        }
        else
        {
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

  [HttpDelete("{id}")]
  public IActionResult Delete(Guid id)
  {
    service.Delete(id);
    return NoContent();
  }
}