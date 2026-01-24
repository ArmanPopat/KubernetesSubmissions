
namespace ToDoApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var port = Environment.GetEnvironmentVariable("PORT");
        if (!string.IsNullOrWhiteSpace(port) && int.TryParse(port, out var portNumber))
        {
            builder.WebHost.ConfigureKestrel(options =>
            {
                options.ListenAnyIP(portNumber);
            });
        }
        else {
            throw new InvalidOperationException("Invalid or unset PORT environment variable");
        }

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }
        
        app.UseAuthorization();
        
        Console.WriteLine("Server started in port {0}",port);
        
        
        app.UseDefaultFiles();   
        app.UseStaticFiles();


        app.Run();

    }
}
