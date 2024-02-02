using Curso.Models;
using Curso.Services;
using Microsoft.AspNetCore.Mvc;
namespace Curso.Controllers;
[ApiController]
[Route("api/[controller]")]
public class EnrollmentController: ControllerBase
{
  public IEnrollmentService service;

  public EnrollmentController(IEnrollmentService es){
    service = es;
  }

  [HttpGet]
  public IActionResult Get(){
    return Ok(service.GetAll());
  }

  [HttpPost]
  public IActionResult Post([FromBody] Enrollment enrollment){
    try
    {
      if (enrollment != null) {
        service.Save(enrollment);
        return CreatedAtAction(nameof(Get), new { Id = enrollment.Id }, enrollment);
      }else{
        return BadRequest("El objeto Matricula no puede ser nulo.");
      }
    }
    catch (Exception ex)
    {
      return StatusCode(500,$"Error interno del servidor {ex}");
    }
  }

  [HttpPut("{id}")]
  public IActionResult Put([FromBody] Enrollment enrollment, Guid id){
    try
    {
      if(enrollment != null){
        service.Update(enrollment, id);
        return Ok($"Matricula Actualizada {id}");
      }else{
        return BadRequest("El objeto Matricula no puede ser nulo.");
      }
    }
    catch (Exception ex)
    {
      return StatusCode(500,$"Error interno en el servidor {ex}");
    }
  }
  [HttpDelete("{id}")]
  public IActionResult Delete(Guid id){
    service.Delete(id);
    return Ok($"id: {id}");
  }
}