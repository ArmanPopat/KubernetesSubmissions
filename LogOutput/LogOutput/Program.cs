namespace LogOutput;

class Program
{
    static async Task Main(string[] args)
    {
        var randString = Guid.NewGuid().ToString();
        using var timer = new PeriodicTimer(TimeSpan.FromSeconds(5));
        while (await timer.WaitForNextTickAsync())
        {
            Console.WriteLine($"{DateTime.UtcNow:O}: {randString}");
        }
    }
}