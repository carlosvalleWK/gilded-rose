using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.Services
{
    internal class QualityDegradeStrategy : IQualityCalculateStrategy
    {
        public int CalculateNewQuality(int quality)
        {
            if (quality > 0)
            {
                return quality - 1;
            }
            return quality;
        }
    }
}
