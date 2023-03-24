using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public abstract class ItemBase
    {
        public string Name { get; private set; }
        public int SellIn { get; private set; }
        public int Quality { get; protected set; }
        public decimal Price { get; protected set; }

        public ItemBase(string name, int sellIn, int quality, decimal price)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
            Price = price;
        }

        public void Update()
        {
            SellIn -= 1;
            EvaluateQuality();
            EvaluatePrice();
        }

        protected abstract int EvaluateQuality();
        protected abstract decimal EvaluatePrice();
    }
}
