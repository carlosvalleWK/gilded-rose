using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.QualityUpdateStrategy
{
    internal class QualityDegradeStrategy : IQualityUpdateStrategy
    {
        public void UpdateQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= (item.SellIn >= 0) ? 1 : 2;
            }
        }
    }
}
