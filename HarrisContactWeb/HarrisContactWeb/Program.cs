using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HarrisContactWeb.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HarrisContactWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                    //enclosing this in a try-catch loop prevents unexpected shutdown, and enables you to pinpoint the error should it occur
                {
                    var context = services.GetRequiredService<HarrisDbContext>();
                    DbInitializer.Intialize(context);
                    //Calling the DbContext, and then intialisng the build of the app based on that contact!
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An Error has Occured whilst Creating the Database");
                    //Logging a database error should it occur
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
