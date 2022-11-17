using Microsoft.EntityFrameworkCore;
using SchoolManagement.DBContext;
using SchoolManagement.Interface;
using SchoolManagement.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
builder.Services.AddTransient<IStudent, StudentRepository>();
builder.Services.AddTransient<IParent, ParentRepository>();
builder.Services.AddTransient<ITeacher, TeacherRepository>();
builder.Services.AddTransient<IStudentTeacher, StudentTeacherRepository>();
builder.Services.AddTransient<ISchool, SchoolRepository>();
builder.Services.AddTransient<Iclassroom, ClassroomRepository>();


builder.Services.AddDbContext<SchoolContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDB")));
builder.Services.AddAutoMapper(typeof(Program).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
