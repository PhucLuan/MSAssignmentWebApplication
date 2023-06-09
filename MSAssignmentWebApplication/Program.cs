using Business;
using Microsoft.EntityFrameworkCore;
using MSAssignmentWebApplication.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<EcomStepMediaContext>(
//        options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
builder.Services.AddBusinessLayer(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSPA", builder =>
    {
        builder.WithOrigins("http://localhost:3000") // Replace with the URL of your SPA
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowSPA");

app.UseAuthorization();

app.MapControllers();

app.Run();
