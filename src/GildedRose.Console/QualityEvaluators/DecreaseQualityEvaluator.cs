using Domain.Models;

namespace GildedRose.Console.QualityEvaluators
{
    public class DecreaseQualityEvaluator : ExpirationQualityEvaluator<ItemBase>
    {
        protected override int EvaluateAfterExpire(ItemBase item)
        {
            return item.Quality - 2;
        }

        protected override int EvaluateBeforeExpire(ItemBase item)
        {
            return item.Quality - 1;
        }
    }
}
