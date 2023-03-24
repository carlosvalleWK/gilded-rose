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
        public decimal EvaluateQualityOf(T item)
        {
            return item.SellIn >= 0 ? EvaluateBeforeExpire(item) : EvaluateAfterExpire(item);
        }

        protected abstract decimal EvaluateBeforeExpire(T item);
        protected abstract decimal EvaluateAfterExpire(T item);

    }
}
