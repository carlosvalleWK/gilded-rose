using Domain.Interfaces;
using Domain.Models;
using System;

namespace GildedRose.Console.PriceEvaluators
{
    public class ConcretePriceEvaluator : IPriceEvaluator<ItemBase>
    {
        public decimal EvaluatePriceOf(ItemBase item)
        {
            return Math.Round(item.Quality * 1.9M, 2);
        }
    }
}
