using GildedRose.Console.DataAccessLayer;
using Microsoft.Extensions.DependencyInjection;

namespace GildedRose.Console.DI
{
    public static class ServiceCollectionExtension
    {
        public static ServiceProvider AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IArticlesRepository, ArticlesRepository>();

            return services.BuildServiceProvider();
        }
    }
}
