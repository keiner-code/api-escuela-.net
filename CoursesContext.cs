using Curso.Models;
using Microsoft.EntityFrameworkCore;
public class CourseContext : DbContext
{
  public DbSet<Course> Courses { get; set; }
  public DbSet<Schedule> Schedules { get; set; }
  public DbSet<Teacher> Teachers { get; set; }
  public DbSet<Note> Notes { get; set; }
  public DbSet<Student> Students {get; set;}
  public DbSet<Enrollment> Enrollments {get; set;}

  public CourseContext(DbContextOptions<CourseContext> options) : base(options) { }

//Server=localhost\\SQLEXPRESS;Database=Course;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Course>(course =>
    {
      course.ToTable("course");
      course.HasKey(p => p.Id);
      course.Property(p => p.Name).IsRequired().HasMaxLength(150);
    });

    modelBuilder.Entity<Schedule>(schedule =>
    {
      schedule.ToTable("schedule");
      schedule.HasKey(i => i.Id);
      //un curso tiene muchos horarios
      schedule.HasOne(s => s.Course).WithMany(s => s.Schedules).HasForeignKey(c => c.CourseId);
      schedule.Property(d => d.Day).IsRequired().HasMaxLength(200);
      schedule.Property(s => s.StartTime);
      schedule.Property(e => e.EndTime);
      schedule.Property(s => s.Section).IsRequired().HasMaxLength(200);
    });

    modelBuilder.Entity<Teacher>(teacher =>
    {
      teacher.ToTable("teacher");
      teacher.HasKey(i => i.Id);
      //muchos horarios tiene un teacher 
      teacher.HasMany(s => s.Schedule).WithOne(t => t.Teacher).HasForeignKey(f => f.TeacherId);
      teacher.Property(n => n.Name).IsRequired().HasMaxLength(200);
      teacher.Property(l => l.LastName).IsRequired().HasMaxLength(200);
      teacher.Property(a => a.Age).IsRequired();
      teacher.Property(g => g.Gender);
      teacher.Property(a => a.Address);
      teacher.Property(e => e.Email).IsRequired();
      teacher.Property(p => p.Phone);
    });

    modelBuilder.Entity<Student>(student => {
      student.ToTable("student");
      student.HasKey(i => i.Id);
      student.Property(n => n.Name).IsRequired().HasMaxLength(200);
      student.Property(l => l.LastName).IsRequired().HasMaxLength(200);
      student.Property(s => s.SecondSurName).IsRequired().HasMaxLength(200);
      student.Property(a => a.Age).IsRequired();
      student.Property(s => s.Sexo).IsRequired().HasMaxLength(100);
    });

    modelBuilder.Entity<Note>(note =>
    {
      note.ToTable("note");
      note.HasKey(i => i.Id);
      //un curso tiene muchas notas 
      note.HasOne(c => c.Course).WithMany(n => n.Notes).HasForeignKey(c => c.CourseId);
      //un estudiante tiene muchas notas
      note.HasOne(c => c.Student).WithMany(n => n.Notes).HasForeignKey(c => c.EstudentId);
      note.Property(n => n.Notes).IsRequired().HasMaxLength(100);
      note.Property(t => t.Term).IsRequired();
      note.Property(d => d.Description);
    });

    modelBuilder.Entity<Enrollment>(enrollment => {
      enrollment.ToTable("enrollment");
      enrollment.HasKey(i => i.Id);
      enrollment.HasOne(s => s.Student).WithOne(e => e.Enrollment).HasForeignKey<Enrollment>(f => f.IdStudent);
      enrollment.Property(d => d.Date);
      enrollment.Property(a => a.Amount);
      enrollment.Property(g => g.Grade);
    });

  }
}
