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
            throw new NotImplementedException();
        }

        protected override int EvaluateBeforeExpire(ItemBase item)
        {
            throw new NotImplementedException();
        }
    }
}
