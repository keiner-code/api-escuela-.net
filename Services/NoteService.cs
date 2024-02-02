using Curso.Models;
using Microsoft.EntityFrameworkCore;

public class NoteService : INoteService
{
  public CourseContext context;
  public NoteService(CourseContext con)
  {
    context = con;
  }
  public IEnumerable<Note> GetAll()
  {
    return context.Notes.Include(c => c.Course).ToList();
  }
  public async Task Save(Note note)
  {
    context.Add(note);
    await context.SaveChangesAsync();
  }
  public async Task Update(Note Changes, Guid id)
  {
    var note = context.Notes.Find(id);
    if (note != null)
    {
      Changes.Id = note.Id;
      Changes.CourseId = note.CourseId;
      Changes.Notes = note.Notes;
      Changes.Term = note.Term;
      Changes.Description = note.Description;
      await context.SaveChangesAsync();
    }
  }
  public async Task Delete(Guid id)
  {
    var note = context.Notes.Find(id);
    if (note != null)
    {
      context.Remove(note);
      await context.SaveChangesAsync();
    }
  }
}
public interface INoteService
{
  IEnumerable<Note> GetAll();
  Task Save(Note note);
  Task Update(Note Changes, Guid id);
  Task Delete(Guid id);
}