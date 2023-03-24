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

        private int _quality;
        public int Quality
        {
            get
            {
                return _quality;
            }
            private set
            {
                if (value > 50)
                    _quality = 50;
                else if (value < 0)
                    _quality = 0;
                else
                    _quality = value;
            }
        }
        public decimal Price { get; private set; }

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
            this.Quality = EvaluateQuality();
            this.Price = EvaluatePrice();
        }

        protected abstract int EvaluateQuality();
        protected abstract decimal EvaluatePrice();
    }
}
