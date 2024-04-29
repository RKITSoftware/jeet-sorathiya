using CPContestRegistration.BL.Interface;
using CPContestRegistration.BL.Service;
using CPContestRegistration.CustomMiddleware;
using CPContestRegistration.Filters;
using Microsoft.OpenApi.Models;
using NLog;
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
        LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
        Configuration = configuration;
    }

    /// <summary>
    /// Configures services required by the application.
    /// </summary>
    /// <param name="services">Collection of services to be configured.</param>
    public void ConfigureServices(IServiceCollection services)
    {
        //services.AddControllers(config =>
        //{
        //    config.Filters.Add(typeof(HandleExceptionFilter));
        //});
        services.AddControllers(configure =>
        {
           // configure.Filters.Add<ValidateModelFilter>();
            configure.Filters.Add<HandleExceptionFilter>();
        });
        services.AddEndpointsApiExplorer();
        // Swagger Service
        services.AddSwaggerGen(c =>
        {
            // Adds basic authentication security definition to Swagger.
            c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "basic",
                In = ParameterLocation.Header,
                Description = "Basic Authorization header"
            });

            // Adds security requirement for basic authentication to Swagger.
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                         new OpenApiSecurityScheme
                          {
                            Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },

                        new string[] {}
                    }
                });
        });

        services.AddTransient<IDatabaseService, DatabaseService>();
        services.AddTransient<IContestManagement, ContestManagement>();
        services.AddTransient<IParticipateManagement, ParticipateManagement>();
        services.AddTransient<IUserManagement, UserManagement>();
        services.AddHttpContextAccessor();
        services.AddScoped<RequestAuthorizationMiddleware>();
        services.AddSingleton<ILoggerService, LoggerService>();
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
        app.UseMiddleware<RequestAuthorizationMiddleware>();
        // Authorize requests
        app.UseAuthorization();

        // Map incoming requests to controller actions
        app.MapControllers();

        // End the request pipeline
        app.Run();

    }
}