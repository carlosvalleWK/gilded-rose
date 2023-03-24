using Domain.Models;
using GildedRose.Console;
using GildedRose.Console.QualityEvaluators;
using Xunit.Sdk;

namespace Test.Evaluators
{
    public class DecreaseQualityEvaluatorTest
    {
        [Fact]
        public void BeforeTest()
        {
            // Given
            DecreaseQualityEvaluator evaluator = new();
            TestingItem item = new("testing-item", 10, 10, 10m);

            // When
            int newQuality = evaluator.EvaluateQualityOf(item);

            // Then
            Assert.Equal(9, newQuality);
        }

        [Fact]
        public void AfterTest()
        {
            // Given
            DecreaseQualityEvaluator evaluator = new();
            TestingItem item = new("testing-item", -10, 10, 10m);

            // When
            int newQuality = evaluator.EvaluateQualityOf(item);

            // Then
            Assert.Equal(8, newQuality);
        }
    }
}
