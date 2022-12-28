using GildedRose.Business.Services;
using GildedRose.Business.Test.Mocks;
using GildedRose.Data.Repositories;
using GildedRose.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GildedRose.Business.Test
{
    public class BasetTest
    {
        protected IServiceProvider Services { get; set; }
        private void SetupDI(IServiceCollection services)
        {
            services.AddScoped<IItemService<AgingItem>, AgingItemService>();
            services.AddScoped<IItemService<ExpiringItem>, ExpiringItemService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IItemRepository, ItemRepositoryMock>();
        }

        [TestInitialize]
        public void Init()
        {
            Services = Host
                .CreateDefaultBuilder()
                .ConfigureServices(s => SetupDI(s))
                .Build()
                .Services;
        }
    }
}
