using Bogus;
using GildedRose.Business.Services;
using GildedRose.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Business.Test
{
    [TestClass]
    public class ExpiringItemServiceTest : BasetTest
    {
        private IItemService<ExpiringItem> ExpiringItemService { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            ExpiringItemService = Services.GetService<IItemService<ExpiringItem>>();
        }

        [TestMethod]
        public void UpdateItemNormalSpeed()
        {
            string itemName = new Faker().Commerce.ProductName();
            int itemQuality = new Faker().Random.Int(5, 10);
            int itemSellIn = new Faker().Random.Int(5, 10);

            ExpiringItem item = new ExpiringItem
            {
                Name = itemName,
                Quality = itemQuality,
                SellIn = itemSellIn
            };

            ExpiringItemService.Update(item);

            Assert.AreEqual(itemName, item.Name);
            Assert.AreEqual(itemQuality - 1, item.Quality);
            Assert.AreEqual(itemSellIn - 1, item.SellIn);
        }

        [TestMethod]
        public void UpdateItemHighSpeed()
        {
            string itemName = new Faker().Commerce.ProductName();
            int itemQuality = new Faker().Random.Int(5, 10);
            int itemSellIn = new Faker().Random.Int(-10, -5);

            ExpiringItem item = new ExpiringItem
            {
                Name = itemName,
                Quality = itemQuality,
                SellIn = itemSellIn
            };

            ExpiringItemService.Update(item);

            Assert.AreEqual(itemName, item.Name);
            Assert.AreEqual(itemQuality - 2, item.Quality);
            Assert.AreEqual(itemSellIn - 1, item.SellIn);
        }
    }
}
