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
        protected override decimal EvaluateAfterExpire(ItemBase item)
        {
            throw new NotImplementedException();
        }

        protected override decimal EvaluateBeforeExpire(ItemBase item)
        {
            throw new NotImplementedException();
        }
    }
}
