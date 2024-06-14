using Dependency_Injection.Extension;
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
        services.AddService();
    }

    /// <summary>
    /// Configures the HTTP request pipeline
    /// </summary>
    /// <param name="app">request pipeline</param>
    /// <param name="environment">hosting environment</param>
    public void Configure(WebApplication app, IWebHostEnvironment environment)
    {

        // Map incoming requests to controller actions
        app.MapControllers();

        // Configure the HTTP request pipeline.
        if (environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // Redirect HTTP requests to HTTPS
        //app.UseHttpsRedirection();

        // Authorize requests
        //app.UseAuthorization();

        // End the request pipeline
        app.Run();

    }
}

