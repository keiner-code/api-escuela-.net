using Curso.Models;
using Curso.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSqlServer<CourseContext>(builder.Configuration.GetConnectionString("DbConection"));

builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();


app.Run();

