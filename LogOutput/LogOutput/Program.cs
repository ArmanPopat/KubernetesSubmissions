namespace LogOutput;

class Program
{
    static void Main(string[] args)
    {
        var randString = Guid.NewGuid().ToString();
        
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
        var app = builder.Build();
        app.MapGet("/", () => $"{DateTime.UtcNow:O}: {randString}");
        // using var timer = new PeriodicTimer(TimeSpan.FromSeconds(5));
        // while (await timer.WaitForNextTickAsync())
        // {
        //     Console.WriteLine($"{DateTime.UtcNow:O}: {randString}");
        // }
        app.Run();
    }
}