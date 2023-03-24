using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ItemEvaluable<TQualityEvaluator, TPriceEvaluator> : ItemBase
        where TQualityEvaluator : class, IQualityEvaluator<ItemBase>
        where TPriceEvaluator : class, IPriceEvaluator<ItemBase>
    {
        private readonly TQualityEvaluator _qualityEvaluator;
        private readonly TPriceEvaluator _priceEvaluator;
        public ItemEvaluable(string name, int sellIn, int quality, decimal price)
            : base(name, sellIn, quality, price)
        {
            // TODO: Create evaluators using factory
        }

        protected override int EvaluateQuality()
        {
            throw new NotImplementedException();
        }
        protected override decimal EvaluatePrice()
        {
            throw new NotImplementedException();
        }
    }
}
