using Core;
using Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;



// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext(connectionString);

builder.Services.AddMapper();

builder.Services.AddServices();
builder.Services.AddFluentValidators();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
//}
app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.WithOrigins("http://localhost:5173");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
