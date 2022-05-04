using Microsoft.EntityFrameworkCore;
using PrimeiraAPI.Models;
using PrimeiraAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddDbContext<_DbContext>(options => options.UseSqlServer(
       builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IClientesRepository, ClientesRepository>();

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

app.Run();
