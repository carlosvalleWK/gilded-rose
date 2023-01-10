using GildedRose.Business.Services;
using GildedRose.Data.Repositories;
using GildedRose.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GildedRose.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            IStoreService storeService = Host
                .CreateDefaultBuilder(args)
                .ConfigureServices(services => SetupDI(services))
                .Build()
                .Services
                .GetService<IStoreService>();

            storeService.UpdateItems();

            System.Console.ReadKey();
        }

        private static void SetupDI(IServiceCollection services)
        {
            services.AddScoped<IItemService<AgingItem>, AgingItemService>();
            services.AddScoped<IItemService<ExpiringItem>, ExpiringItemService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IItemRepository, ItemRepository>();
        }
    }
}
