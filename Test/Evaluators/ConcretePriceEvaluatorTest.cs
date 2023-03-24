using GildedRose.Console.PriceEvaluators;

namespace Test.Evaluators
{
    public class ConcretePriceEvaluatorTest
    {
        [Fact]
        public void EvaluatePriceOfTest()
        {
            // Given
            ConcretePriceEvaluator evaluator = new();
            TestingItem item = new("testing-item", 10, 10, 10m);

            // When
            decimal newPrice = evaluator.EvaluatePriceOf(item);

            // Then
            Assert.Equal(newPrice, Math.Round(item.Quality * 1.9M, 2));
        }
    }
}
