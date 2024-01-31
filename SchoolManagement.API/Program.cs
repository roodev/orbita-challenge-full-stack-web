using Microsoft.EntityFrameworkCore;
using SchoolManagement.API.Models;
using SchoolManagement.API.Repository;
using SchoolManagement.API.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SchoolManagementContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepository, StudentRepository>();
builder.Services.AddScoped<IService<Student>, StudentServices>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
      policy =>
      {
          policy.AllowAnyOrigin()
             .AllowAnyHeader()
             .AllowAnyMethod();
      });
});



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();