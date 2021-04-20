using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace PizzaBox
{
    /// <summary>
    /// This is the entry point of the program
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // Enable StartUp to register services
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
