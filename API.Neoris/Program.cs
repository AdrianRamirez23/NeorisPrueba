using API.Neoris.Application.Contracts;
using API.Neoris.Application.Interfaces;
using API.Neoris.Infraestructure.NeorisContext;
using API.Neoris.Services.Contracts;
using API.Neoris.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var configuration = builder.Configuration;



builder.Services.AddDbContext<NeorisContext>(options => options.UseSqlServer(configuration.GetConnectionString("NeorisConnect")));


builder.Services.AddTransient<IUsuarioApp, UsuariosApp>();
builder.Services.AddTransient<IUsuarioSrvs, UsuarioSrvs>();
builder.Services.AddTransient<ICuentaApp, CuentaApp>();
builder.Services.AddTransient<ICuentaSrvs, CuentaSrvs>();


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
