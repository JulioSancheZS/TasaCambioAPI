using Microsoft.EntityFrameworkCore;
using ServiceReference1;
using TasaCambioAPI.Models;
using TasaCambioAPI.Repository.Contrato;
using TasaCambioAPI.Repository.Implementacion;
using static ServiceReference1.Tipo_Cambio_BCNSoapClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cadena de conexion
builder.Services.AddDbContext<TasaCambioDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQlServerConnection"));
});
//Repositorios
builder.Services.AddScoped<ITasaCambioService, TasaCambioService>();

//Servicio Soap Tipo_Cambio_BCNSoapClient
builder.Services.AddScoped(serviceProvider =>
{
    var endpointConfiguration = EndpointConfiguration.Tipo_Cambio_BCNSoap;
    return new Tipo_Cambio_BCNSoapClient(endpointConfiguration);
});

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
