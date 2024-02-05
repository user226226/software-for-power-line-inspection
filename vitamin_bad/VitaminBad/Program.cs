using VitaminBad.Data;
using Microsoft.EntityFrameworkCore;
using VitaminBad.Data.Interface;
using VitaminBad.Data.Repository;
using VitaminBad.Domain.Entity;
using Microsoft.AspNetCore.Authentication.OAuth;
using VitaminBad.Service.Interfaces;
using VitaminBad.Service.Implements;

var builder = WebApplication.CreateBuilder(args);

var con = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(con));

builder.Services.AddScoped<IBaseRepository<Coordinate>, CoordinateRepository>();
builder.Services.AddScoped<IBaseRepository<Dron>, DronRepository>();
builder.Services.AddScoped<IBaseRepository<Emploee>, EmploeeRepository>();
builder.Services.AddScoped<IBaseRepository<StatusEvent>, StatusEventRepository>();
builder.Services.AddScoped<IBaseRepository<TypeEvent>, TypeEventRepository>();
builder.Services.AddScoped<IBaseRepository<PNagruzka>, PNagruzkaRepository>();
builder.Services.AddScoped<IBaseRepository<VitaminBad.Domain.Entity.Path>, PathRepository>();
builder.Services.AddScoped<IBaseRepository<Event>, EventRepository>();
builder.Services.AddScoped<IBaseRepository<Crew>, CrewRepository>();

builder.Services.AddScoped<ICoordinateService, CoordinateService>();
builder.Services.AddScoped<IEventService, EventService>();

var auth = builder.Configuration.GetSection("Auth");

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builderr =>
        {
            builderr.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        }
        );
});

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

app.UseAuthorization();

app.MapControllers();

app.UseCors();
app.Run();
