using Bogus;
using GildedRose.Business.Services;
using GildedRose.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Business.Test
{
    [TestClass]
    public class AgingItemServiceTest : BasetTest
    {
        private IItemService<AgingItem> AgingItemService { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            AgingItemService = Services.GetService<IItemService<AgingItem>>();
        }

        [TestMethod]
        public void UpdateItemNormalSpeed()
        {
            string itemName = new Faker().Commerce.ProductName();
            int itemQuality = new Faker().Random.Int(5, 10);
            int itemSellIn = new Faker().Random.Int(5, 10);

            AgingItem item = new AgingItem
            {
                Name = itemName,
                Quality = itemQuality,
                SellIn = itemSellIn
            };

            AgingItemService.Update(item);

            Assert.AreEqual(itemName, item.Name);
            Assert.AreEqual(itemQuality + 1, item.Quality);
            Assert.AreEqual(itemSellIn - 1, item.SellIn);
        }

        [TestMethod]
        public void UpdateItemHighSpeed()
        {
            string itemName = new Faker().Commerce.ProductName();
            int itemQuality = new Faker().Random.Int(5, 10);
            int itemSellIn = new Faker().Random.Int(-10, -5);

            AgingItem item = new AgingItem
            {
                Name = itemName,
                Quality = itemQuality,
                SellIn = itemSellIn
            };

            AgingItemService.Update(item);

            Assert.AreEqual(itemName, item.Name);
            Assert.AreEqual(itemQuality + 2, item.Quality);
            Assert.AreEqual(itemSellIn - 1, item.SellIn);
        }
    }
}
