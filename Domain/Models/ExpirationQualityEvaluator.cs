using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public abstract class ExpirationQualityEvaluator<T> : IQualityEvaluator<T>
        where T : ItemBase
    {
        public int EvaluateQualityOf(T item)
        {
            return item.SellIn >= 0 ? EvaluateBeforeExpire(item) : EvaluateAfterExpire(item);
        }

        protected abstract int EvaluateBeforeExpire(T item);
        protected abstract int EvaluateAfterExpire(T item);

    }
}
