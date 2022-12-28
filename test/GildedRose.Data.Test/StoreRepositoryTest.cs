using Bogus;
using GildedRose.Data.Repositories;
using GildedRose.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Data.Test
{
    [TestClass]
    public class StoreRepositoryTest
    {
        private IItemRepository ItemRepository { get; set; }

        private void SetupDI(IServiceCollection services)
        {
            services.AddScoped<IItemRepository, ItemRepository>();
        }

        [TestInitialize]
        public void Init()
        {
            IServiceProvider services = Host
                .CreateDefaultBuilder()
                .ConfigureServices(s => SetupDI(s))
                .Build()
                .Services;

            ItemRepository = services.GetService<IItemRepository>();
        }

        [TestMethod]
        public void UpdateAndReadItems()
        {
            IEnumerable<Item> items = FakeItems();

            ItemRepository.UpdateItems(items);

            IEnumerable<Item> actualItems = ItemRepository.GetItems();

            Assert.AreEqual(items.Count(), actualItems.Count());
            for (int i = 0; i < items.Count(); i++)
                Assert.AreEqual(items.ToList()[i], actualItems.ToList()[i]);
        }

        public IEnumerable<Item> FakeItems() =>
            Enumerable.Range(1, new Faker().Random.Int(1, 100))
                .Select(
                    i =>
                    {
                        if (new Faker().Random.Bool())
                            return (Item) FakeItem<ExpiringItem>();
                        else
                            return (Item) FakeItem<AgingItem>();
                    }
                )
                .ToList();

        public ItemType FakeItem<ItemType>() where ItemType : Item =>
            new Faker<ItemType>()
                .RuleFor(i => i.Name, f => f.Commerce.ProductName())
                .RuleFor(i => i.SellIn, f => f.Random.Number(0, 100))
                .RuleFor(i => i.Quality, f => f.Random.Number(10, 40))
                .Generate();
    }
}
