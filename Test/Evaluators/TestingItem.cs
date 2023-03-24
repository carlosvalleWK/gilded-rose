using Domain.Models;

namespace Test.Evaluators
{
    public class TestingItem : ItemBase
    {
        public TestingItem(string name, int sellIn, int quality, decimal price) : base(name, sellIn, quality, price)
        {
        }

        protected override decimal EvaluatePrice()
        {
            throw new NotImplementedException();
        }

        protected override int EvaluateQuality()
        {
            throw new NotImplementedException();
        }
    }
}
