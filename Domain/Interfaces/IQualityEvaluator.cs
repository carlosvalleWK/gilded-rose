using Domain.Models;

namespace Domain.Interfaces
{
    public interface IQualityEvaluator<T> where T : ItemBase
    {
        int EvaluateQualityOf(T item);
    }
}
