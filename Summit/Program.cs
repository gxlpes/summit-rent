using Microsoft.EntityFrameworkCore;
using Summit.Data;
using Summit.Models;
using Summit.Controller;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>
(options => options.UseMySql(
"server=localhost;port=3306;initial catalog=summit;uid=root;pwd=123",
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.1.0-mysql")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseAuthorization();

app.Run();
