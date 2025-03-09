using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Register controllers for API endpoints.

builder.Services.AddEndpointsApiExplorer(); // Enable endpoint discovery for Swagger.
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MyWebApi",
        Version = "v1",
        Description = "A simple API to demonstrate Swagger UI in .NET Core"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI in development environment.
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "MyWebApi v1");
        options.RoutePrefix = string.Empty; // This will launch Swagger UI at the root URL (e.g., http://localhost:5000/).
    });
}

// Enable routing and controllers.
app.UseRouting();

app.MapControllers(); // Map the controller actions to HTTP routes.

app.Run();
