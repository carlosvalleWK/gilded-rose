using Domain.Interfaces;
using Domain.Models;
using System;

namespace GildedRose.Console.PriceEvaluators
{
    public class ConcretePriceEvaluator : IPriceEvaluator<ItemBase>
    {
        public decimal EvaluatePriceOf(ItemBase item)
        {
            throw new NotImplementedException();
        }
    }
}
