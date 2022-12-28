using GildedRose.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Business.Test
{
    [TestClass]
    public class StoreServiceTest : BasetTest
    {
        private IStoreService StoreService { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            StoreService = Services.GetService<IStoreService>();
        }

        [TestMethod]
        public void UpdateItems()
        {
            StoreService.UpdateItems();
        }
    }
}
