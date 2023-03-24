using Domain.Interfaces;

namespace Domain.Models
{
    public class ItemEvaluable<TQualityEvaluator, TPriceEvaluator> : ItemBase
        where TQualityEvaluator : class, IQualityEvaluator<ItemBase>, new()
        where TPriceEvaluator : class, IPriceEvaluator<ItemBase>, new()
    {
        private readonly TQualityEvaluator _qualityEvaluator;
        private readonly TPriceEvaluator _priceEvaluator;
        public ItemEvaluable(string name, int sellIn, int quality, decimal price)
            : base(name, sellIn, quality, price)
        {
            _qualityEvaluator = new();
            _priceEvaluator = new();
        }

        public ItemEvaluable(string name, int sellIn, int quality) : this(name, sellIn, quality, 0m)
        {
            // NOOP
        }

        protected override int EvaluateQuality()
        {
            return _qualityEvaluator.EvaluateQualityOf(this);
        }
        protected override decimal EvaluatePrice()
        {
            return _priceEvaluator.EvaluatePriceOf(this);
        }
    }
}
