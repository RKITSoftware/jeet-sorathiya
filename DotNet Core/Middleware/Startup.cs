﻿using Microsoft.AspNetCore.Mvc;
using Middleware.CustomMiddleware;
using System.Reflection.Metadata;
/// <summary>
/// Class responsible for configuring the application during startup.
/// </summary>
public class Startup
{
    /// <summary>
    /// Configuration property containing the application's configuration.
    /// </summary>
    public IConfiguration Configuration { get; }

    /// <summary>
    /// Constructor for the Startup class.
    /// </summary>
    /// <param name="configuration">The application's configuration.</param>
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    /// <summary>
    /// Configures services required by the application.
    /// </summary>
    /// <param name="services">Collection of services to be configured.</param>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddSingleton<CustomMiddleware>(); // add customMiddleware
        ScanForCustomAttributes(services);
    }

    /// <summary>
    /// Configures the HTTP request pipeline
    /// </summary>
    /// <param name="app">request pipeline</param>
    /// <param name="environment">hosting environment</param>
    public void Configure(WebApplication app, IWebHostEnvironment environment)
    {
        // Configure the HTTP request pipeline.
        if (environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // Redirect HTTP requests to HTTPS
        app.UseHttpsRedirection();

        // Authorize requests
        app.UseAuthorization();

        // Map incoming requests to controller actions
        app.MapControllers();

        app.MapGet("/api/resource", async context =>
        {
            await Task.Delay(10000); // Simulate an asynchronous operation
            await context.Response.WriteAsync("Done");
        });

        // Call CustomMiddleware
        app.UseMiddleware<CustomMiddleware>();

        // StaticFile Middleware
        app.UseStaticFiles();


        // End the request pipeline
        app.Run();

    }

    private void ScanForCustomAttributes(IServiceCollection services)
    {
        var controllers = typeof(Startup).Assembly.GetTypes()
            .Where(type => typeof(ControllerBase).IsAssignableFrom(type));

        foreach (var controller in controllers)
        {
            var customAttributes = controller.GetCustomAttributes(typeof(CustomAttribute), true);

            foreach (CustomAttribute attribute in customAttributes)
            {              
                Console.WriteLine($"Controller: {controller}, Attribute: {attribute}");
               
            }
        }
    }
}