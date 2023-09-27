using Microsoft.EntityFrameworkCore;
using Summit.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
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
