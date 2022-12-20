
namespace GildedRose.Console.Tests
{
    public class QualityDegradeStrategyTests
    {
        private readonly Program _program = new Program();
        [Fact]
        public void DegradeTest()
        {
            //arrange
            int sellIn = 10;
            int quality = 20;
            var testItem = new Item
            {
                Name = "DegradeTest",
                SellIn = sellIn,
                Quality = quality
            };

            _program.Items = new List<Item>() { testItem };

            //act
            _program.UpdateQuality();

            //assert
            Assert.Equal(sellIn - 1, testItem.SellIn);
            Assert.Equal(quality -1, testItem.Quality);
            Assert.Equal(_program.CalulatePrice(quality - 1), testItem.Price);
        }

        [Fact]
        public void ZeroQualityDegradeTest()
        {
            //arrange
            int sellIn = 10;
            int quality = 0;
            var testItem = new Item
            {
                Name = "ZeroQualityDegradeTest",
                SellIn = sellIn,
                Quality = quality
            };

            _program.Items = new List<Item>() { testItem };

            //act
            _program.UpdateQuality();

            //assert
            Assert.Equal(sellIn - 1, testItem.SellIn);
            Assert.Equal(0, testItem.Quality);
            Assert.Equal(_program.CalulatePrice(0), testItem.Price);
        }

        [Fact]
        public void DobleDegradeTest()
        {
            //arrange
            int sellIn = 0;
            int quality = 20;
            var testItem = new Item
            {
                Name = "ZeroQualityDegradeTest",
                SellIn = sellIn,
                Quality = quality
            };

            _program.Items = new List<Item>() { testItem };

            //act
            _program.UpdateQuality();

            //assert
            Assert.Equal(sellIn - 1, testItem.SellIn);
            Assert.Equal(quality - 2, testItem.Quality);
            Assert.Equal(_program.CalulatePrice(quality - 2), testItem.Price);
        }

        [Fact]
        public void ZeroDobleDegradeTest()
        {
            //arrange
            int sellIn = 0;
            int quality = 0;
            var testItem = new Item
            {
                Name = "ZeroQualityDegradeTest",
                SellIn = sellIn,
                Quality = quality
            };

            _program.Items = new List<Item>() { testItem };

            //act
            _program.UpdateQuality();

            //assert
            Assert.Equal(sellIn - 1, testItem.SellIn);
            Assert.Equal(quality, testItem.Quality);
            Assert.Equal(_program.CalulatePrice(quality), testItem.Price);
        }
    }
}