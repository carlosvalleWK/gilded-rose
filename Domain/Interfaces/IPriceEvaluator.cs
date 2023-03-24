using Domain.Models;

namespace Domain.Interfaces
{
    public interface IPriceEvaluator<T> where T : ItemBase
    {
        decimal EvaluatePriceOf(T item);
    }
}
