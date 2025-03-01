﻿using DoctorService.Data;
using DoctorService.Repositories;
using DoctorService.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // Allow Angular app
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials();
        });
});

// Add services to the container.
// ✅ Add this line to register the service in Dependency Injection (DI)
builder.Services.AddScoped<IDoctorService, DoctorService.Services.DoctorService>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();

builder.Services.AddDbContext<DoctorDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAngular"); // ✅ Apply CORS policy

app.UseAuthorization();

app.MapControllers();

app.Run();
