
#region  Default Code
//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run(); 
#endregion

using DemoProject;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a new WebApplicationBuilder instance
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Create a new instance of the Startup class, passing the application's configuration to it.
        Startup startup = new Startup(builder.Configuration);

        // Configuring Services
        startup.ConfigureServices(builder.Services);

        // Build the web application using the configured services
        WebApplication app = builder.Build();

        // Configure the application and its environment
        startup.Configure(app, builder.Environment);
    }
}
