using GildedRose.Business.Services;
using GildedRose.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            IItemService storeService = Host
            .CreateDefaultBuilder(args)
            .ConfigureServices(services => addServices(services))
            .Build()
            .Services
            .GetService<IItemService>();

            storeService.UpdateItems();

            System.Console.ReadKey();

        }
        private static void addServices(IServiceCollection services)
        {
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IItemRepository, ItemRepository>();
        }
    }
}
