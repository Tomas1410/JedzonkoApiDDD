using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Foodly.Api
{
    //Klasa uruchamiaj�ca serwer webowy i uruchamiaj�ca klas� startow� Startup
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}