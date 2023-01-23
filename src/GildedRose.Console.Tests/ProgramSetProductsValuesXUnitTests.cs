using GildedRose.Domain.Products;

namespace GildedRose.Console.Tests
{
    public class ProgramSetProductsValuesXUnitTests
    {
        private readonly Program target = new();
        private Product? testProduct;
        private AgedBrieProduct? testAgedBrieProduct;

        [Fact]
        public void ProductDecreaseSellIn()
        {
            testProduct = new Product
            {
                Name = "+5 Dexterity Vest",
                SellIn = 10,
                Quality = 20
            };
            target.Products = new List<Product> { testProduct };

            target.Products = target.SetProductsValues(target.Products);

            testProduct.SellIn.ShouldBe(9);
        }

        [Fact]
        public void ProductDecreaseQuality()
        {
            testProduct = new Product
            {
                Name = "+5 Dexterity Vest",
                SellIn = 10,
                Quality = 20
            };
            target.Products = new List<Product> { testProduct };

            target.Products = target.SetProductsValues(target.Products);

            testProduct.Quality.ShouldBe(19);
        }

        [Fact]
        public void ProductDecreaseSellInBellowZero()
        {
            testProduct = new Product
            {
                Name = "+5 Dexterity Vest",
                SellIn = 0,
                Quality = 20
            };
            target.Products = new List<Product> { testProduct };

            target.Products = target.SetProductsValues(target.Products);

            testProduct.SellIn.ShouldBe(-1);
        }

        [Fact]
        public void ProductDecreaseQualityBelowZeroTwice()
        {
            testProduct = new Product
            {
                Name = "+5 Dexterity Vest",
                SellIn = 0,
                Quality = 20
            };
            target.Products = new List<Product> { testProduct };

            target.Products = target.SetProductsValues(target.Products);

            testProduct.Quality.ShouldBe(18);
        }

        [Fact]
        public void ProductDecreaseQualityOfTwoToZero()
        {
            testProduct = new Product
            {
                Name = "+5 Dexterity Vest",
                SellIn = 0,
                Quality = 2
            };
            target.Products = new List<Product> { testProduct };

            target.Products = target.SetProductsValues(target.Products);

            testProduct.Quality.ShouldBe(0);
        }

        [Fact]
        public void ProductDecraseQualityLimitedToZero()
        {
            testProduct = new Product
            {
                Name = "+5 Dexterity Vest",
                SellIn = 0,
                Quality = 1
            };
            target.Products = new List<Product> { testProduct };

            target.Products = target.SetProductsValues(target.Products);

            testProduct.Quality.ShouldBe(0);
        }

        [Fact]
        public void ProductNotAllowedDecreaseQualityLimitedToZeroFromZeroValue()
        {
            testProduct = new Product
            {
                Name = "+5 Dexterity Vest",
                SellIn = 0,
                Quality = 0
            };
            target.Products = new List<Product> { testProduct };

            target.Products = target.SetProductsValues(target.Products);

            testProduct.Quality.ShouldBe(0);
        }

        [Fact]
        public void AgedBrieProductDecreaseSellIn()
        {
            testAgedBrieProduct = new AgedBrieProduct
            {
                Name = "Aged Brie",
                SellIn = 10,
                Quality = 20
            };
            target.Products = new List<Product> { testAgedBrieProduct };

            target.Products = target.SetProductsValues(target.Products);

            testAgedBrieProduct.SellIn.ShouldBe(9);
        }

        [Fact]
        public void AgedBrieProductIncreaseQualityTwiceToMaxAllowed()
        {
            testAgedBrieProduct = new AgedBrieProduct
            {
                Name = "Aged Brie",
                SellIn = 0,
                Quality = 48
            };
            target.Products = new List<Product> { testAgedBrieProduct };

            target.Products = target.SetProductsValues(target.Products);

            testAgedBrieProduct.Quality.ShouldBe(50);
        }

        [Fact]
        public void AgedBrieProductIncreaseQualityToMaxAllowedWithZeroSellInValue()
        {
            testAgedBrieProduct = new AgedBrieProduct
            {
                Name = "Aged Brie",
                SellIn = 0,
                Quality = 49
            };
            target.Products = new List<Product> { testAgedBrieProduct };

            target.Products = target.SetProductsValues(target.Products);

            testAgedBrieProduct.Quality.ShouldBe(50);
        }

        [Fact]
        public void AgedBrieProductIncreaseQualityToMaxAllowedWithTenSellInValue()
        {
            testAgedBrieProduct = new AgedBrieProduct
            {
                Name = "Aged Brie",
                SellIn = 10,
                Quality = 49
            };
            target.Products = new List<Product> { testAgedBrieProduct };

            target.Products = target.SetProductsValues(target.Products);

            testAgedBrieProduct.Quality.ShouldBe(50);
        }

        [Fact]
        public void AgedBrieProductLimitQualityToMax()
        {
            testAgedBrieProduct = new AgedBrieProduct
            {
                Name = "Aged Brie",
                SellIn = 10,
                Quality = 50
            };
            target.Products = new List<Product> { testAgedBrieProduct };

            target.Products = target.SetProductsValues(target.Products);

            testAgedBrieProduct.Quality.ShouldBe(50);
        }
    }
}