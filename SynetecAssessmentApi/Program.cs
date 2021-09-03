using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SynetecAssessmentApi.Persistence;
using SynetecAssessmentApi.Persistence.Config;

namespace SynetecAssessmentApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                IServiceProvider services = scope.ServiceProvider;
                AppDbContext context = services.GetRequiredService<AppDbContext>();
            
                DbContextGenerator.Initialize(services);
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
