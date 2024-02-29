using CollegeManagement.API.Core.Domain.Procedures;
using CollegeManagement.API.Data.CommandsHandler;
using CollegeManagement.API.Data.Mappers;
using CollegeManagement.API.Web.DependencyRegistration;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Get all stored procedures from appsettings.json file
builder.Services.Configure<StoreProcedures>(builder.Configuration.GetSection("StoreProcedures"));

//read appsettings.json file
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

//Handle all Exceptions and log are maintains in one drive file with help of  AddSerilog service
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add services to the container.
builder.Services.AddControllers(
    setupAction =>
    {
        setupAction.Filters.Add(new ProducesAttribute("application/json"));
        setupAction.Filters.Add(new ConsumesAttribute("application/json"));
    }).AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add MediatR service
builder.Services
    .AddMediatR(cfg =>
    {
        cfg.RegisterServicesFromAssemblies(typeof(CollegeManagement.API.Services.MediatRInjection).Assembly, typeof(CollegeManagement.API.Data.MediatRInjection).Assembly);
    });

//Add AddAutoMapper service
builder.Services.AddAutoMapper(typeof(CollegeMapper));

//Register all custom dependency services
builder.Services.RegisterDataDependencies(builder.Configuration);

builder.Services.AddCors(opt => opt.AddPolicy("CorsPolicy", c =>
{
      c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
