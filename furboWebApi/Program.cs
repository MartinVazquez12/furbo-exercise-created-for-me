using FluentValidation.AspNetCore;
using furboWebApi.Mappings;
using furboWebApi.Models;
using furboWebApi.Repositories;
using furboWebApi.Repositories.Interfaces;
using furboWebApi.Services;
using furboWebApi.Services.Interfaz;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//REPOS-SERVICES
builder.Services.AddScoped<IJugadorRepo, JugadorRepo>();
builder.Services.AddScoped<IClubRepo, ClubRepo>();
builder.Services.AddScoped<IRecuperatorioService, RecuperatorioService>();

//FLUENT
builder.Services.AddFluentValidation((options) =>
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly())
);

//AUTOMAPPER
builder.Services.AddAutoMapper(typeof(MappingProfile));

//DBCONTEXT
builder.Services.AddDbContext<FurboDbContext>((context) =>
{
    context.UseSqlServer(builder.Configuration.GetConnectionString("furboDB"));
});


var app = builder.Build();

//CORS
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

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
