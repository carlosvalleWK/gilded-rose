using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.QualityEvaluators
{
    public class IncreaseQualityEvaluator : ExpirationQualityEvaluator<ItemBase>
    {
        protected override int EvaluateAfterExpire(ItemBase item)
        {
            return item.Quality + 2;
        }

        protected override int EvaluateBeforeExpire(ItemBase item)
        {
            return item.Quality + 1;
        }
    }
}
