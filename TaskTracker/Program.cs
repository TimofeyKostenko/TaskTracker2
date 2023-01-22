using Business.Interfaces;
using Business;
using DAL;
using DAL.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IBaseRepository<Mission>, MissionRepository>();
builder.Services.AddScoped<IBaseRepository<Project>, ProjectRepository>();

builder.Services.AddScoped<IMissionService, MissionService>();
builder.Services.AddScoped<IProjectService, ProjectService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(connection, b => b.MigrationsAssembly("TaskTracker")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
