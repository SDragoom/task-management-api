using Microsoft.EntityFrameworkCore;
using Serilog;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Services;
using TaskManagement.Infrastructure.Data;
using TaskManagement.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using TaskManagement.Application.Validators;
using TaskManagement.Api.Middlewares;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters
            .Add(new JsonStringEnumConverter());
    });
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateTaskValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SupportNonNullableReferenceTypes();
    options.UseInlineDefinitionsForEnums();

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Task Management API",
        Version = "v1",
        Description = "Simple REST API for task management built with ASP.NET Core and Clean Architecture.",
        Contact = new OpenApiContact
        {
            Name = "Marcelo Peres"
        }
    });

    var apiXmlFile =
      $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var apiXmlPath =
        Path.Combine(AppContext.BaseDirectory, apiXmlFile);

    options.IncludeXmlComments(apiXmlPath);

    var applicationXmlFile = "TaskManagement.Application.xml";
    var applicationXmlPath =
        Path.Combine(AppContext.BaseDirectory, applicationXmlFile);

    options.IncludeXmlComments(applicationXmlPath);
});
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("TaskDb"));

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();