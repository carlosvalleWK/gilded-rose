using Domain.Interfaces;
using Domain.Models;

namespace Test.Model
{
    public class ItemEvaluableTest
    {
        [Fact]
        public void UpdateItem_QualityUpperLimitTest()
        {
            // Given
            ItemEvaluable<TestingIncreaseQualityEvaluator, TestingPermanentPriceEvaluator> item = new("increase-item", 10, 20, 10m);

            // When
            item.Update();

            // Then
            Assert.True(item.Quality == 50);
        }

        [Fact]
        public void UpdateItem_QualityLowerLimit_Test()
        {
            // Given
            ItemEvaluable<TestingDecreaseQualityEvaluator, TestingPermanentPriceEvaluator> item = new("decrease-item", 10, 20, 10m);

            // When
            item.Update();

            // Then
            Assert.True(item.Quality == 0);
        }

        [Fact]
        public void UpdateItem()
        {
            // Given
            ItemEvaluable<TestingMinorIncreaseQualityEvaluator, TestingPermanentPriceEvaluator> item = new("decrease-item", 10, 20, 10m);

            // When
            item.Update();

            // Then
            Assert.Equal(40, item.Quality);
            Assert.Equal(9, item.SellIn);
        }

        public class TestingPermanentPriceEvaluator : IPriceEvaluator<ItemBase>
        {
            public decimal EvaluatePriceOf(ItemBase item)
            {
                return item.Price;
            }
        }

        public class TestingIncreaseQualityEvaluator : IQualityEvaluator<ItemBase>
        {
            public int EvaluateQualityOf(ItemBase item)
            {
                return 60;
            }
        }

        public class TestingMinorIncreaseQualityEvaluator : IQualityEvaluator<ItemBase>
        {
            public int EvaluateQualityOf(ItemBase item)
            {
                return item.Quality + 20;
            }
        }

        public class TestingDecreaseQualityEvaluator : IQualityEvaluator<ItemBase>
        {
            public int EvaluateQualityOf(ItemBase item)
            {
                return -60;
            }
        }
    }
}
