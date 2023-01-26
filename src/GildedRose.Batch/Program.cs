using GildedRose.Batch.Services;
using GildedRose.Domain.Business;
using GildedRose.Domain.Configurations;
using GildedRose.Domain.Interfaces.Business;
using GildedRose.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
        {
            services.AddSingleton<IProcessItems, ProcessItems>();
            services.AddTransient<IItemGenerator, ItemGenerator>();
            services.AddTransient<IProcessQualityItems, ProcessQualityItems>();
            services.AddTransient<IQualityItems, QualityItems>();
            services.AddSingleton(x =>
            {
                var config = x.GetRequiredService<IConfiguration>();
                return config.Get<DomainConfiguration>();
            });
        });


var host = CreateHostBuilder(args).Build();

var app = host.Services.GetRequiredService<IProcessItems>();

app.Process();
