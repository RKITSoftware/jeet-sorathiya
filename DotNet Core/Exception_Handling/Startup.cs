using Microsoft.AspNetCore.Diagnostics;
using System.ComponentModel.Design.Serialization;
using System.Net;
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
            //app.UseDeveloperExceptionPage(new DeveloperExceptionPageOptions
            //{
            //    SourceCodeLineCount = 2 // number of source code lines
            //});
            app.UseExceptionHandler(
               options =>
               {
                   options.Run(
                       async context =>
                       {
                           context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                           var ex = context.Features.Get<IExceptionHandlerFeature>();
                           if (ex != null)
                           {
                               await context.Response.WriteAsync(ex.Error.Message);
                           }
                       }
                );
               }
            );
        }

        app.MapGet("/", async context =>
        {
            int Number1 = 10, Number2 = 0;
            int Result = Number1 / Number2; //This statement will throw Runtime Exception
            await context.Response.WriteAsync($"Result : {Result}");
        });
        // Redirect HTTP requests to HTTPS
        app.UseHttpsRedirection();

        // Authorize requests
        app.UseAuthorization();

        // Map incoming requests to controller actions
        app.MapControllers();

        // End the request pipeline
        app.Run();

    }
}