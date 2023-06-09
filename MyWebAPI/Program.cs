using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var str = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BookContext>(options => options.UseSqlServer(str));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())        // ���Ǧ��t�O�A1st
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();                  // ���Ǧ��t�O�A2nd

app.UseAuthorization();                     // ���Ǧ��t�O�A3rd

app.MapControllers();                       // ���Ǧ��t�O�A4th

app.Run();
