using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Foodly.Api
{
    //Klasa uruchamiaj¹ca serwer webowy i uruchamiaj¹ca klasê startow¹ Startup
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