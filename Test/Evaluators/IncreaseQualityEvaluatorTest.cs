using GildedRose.Console.QualityEvaluators;
using static Test.Evaluators.DecreaseQualityEvaluatorTest;

namespace Test.Evaluators
{
    public class IncreaseQualityEvaluatorTest
    {
        [Fact]
        public void BeforeTest()
        {
            // Given
            IncreaseQualityEvaluator evaluator = new();
            TestingItem item = new("testing-item", 10, 10, 10m);

            // When
            int newQuality = evaluator.EvaluateQualityOf(item);

            // Then
            Assert.Equal(11, newQuality);
        }

        [Fact]
        public void AfterTest()
        {
            // Given
            IncreaseQualityEvaluator evaluator = new();
            TestingItem item = new("testing-item", -10, 10, 10m);

            // When
            int newQuality = evaluator.EvaluateQualityOf(item);

            // Then
            Assert.Equal(12, newQuality);
        }
    }
}
