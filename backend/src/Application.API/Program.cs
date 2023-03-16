using Microsoft.EntityFrameworkCore;
using Infra.Data.Repository.Data;
using Domain.Interfeces.IRepositories;
using Infra.Data.Repository.Repositories;
using Domain.Interfeces.IServices;
using Application.Service.MySQLServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy",
        builder =>
        {
            builder.WithOrigins("*");
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
            builder.AllowAnyOrigin();
        }
    );
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string ConnectionString = builder.Configuration.GetConnectionString("MySQLConnection");
builder.Services.AddDbContext<MySqlContext>
    (options => options.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString)));

// # Dependency Injection
// Repositories
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IOccurrenceRepository, OccurrenceRepository>();
builder.Services.AddScoped<IResolutionRepository, ResolutionRepository>();

// Services
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IOccurrenceService, OccurrenceService>();
builder.Services.AddScoped<IResolutionService, ResolutionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
