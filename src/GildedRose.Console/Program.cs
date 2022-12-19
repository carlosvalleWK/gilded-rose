using GildedRose.Console.Entities;
using GildedRose.Console.Repository;
using GildedRose.Console.Services;
using GildedRose.Console.Services.Application;
using GildedRose.Console.Services.Console;
using GildedRose.Console.Services.Quality;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace GildedRose.Console
{
    public class Program
    {
        public IConfigurationRoot Configuration { get; }

        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<IApplication, Application>();
                services.AddSingleton<IConsoleService, ConsoleService>();
                services.AddTransient<IProductService, ProductService>();
                services.AddTransient<IProductRepository, ProductRepository>();
                services.AddTransient<IQualityService, QualityService>();
                services.AddTransient<IOldQualityService, OldQualityService>();
            }).Build();

            var app = host.Services.GetRequiredService<IApplication>();
            app.Run();
        }
    }
}
