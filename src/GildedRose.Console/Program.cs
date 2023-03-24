using Domain.Models;
using GildedRose.Console.PriceEvaluators;
using GildedRose.Console.QualityEvaluators;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<ItemBase> Items;

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<ItemBase>()
                {
                    new ItemEvaluable<DecreaseQualityEvaluator, ConcretePriceEvaluator>("+5 Dexterity Vest", 10, 20),
                    new ItemEvaluable<IncreaseQualityEvaluator, ConcretePriceEvaluator>("Aged Brie", 2, 0),
                    new ItemEvaluable<DecreaseQualityEvaluator, ConcretePriceEvaluator>("Elixir of the Mongoose", 5, 7)
                }
            };

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
                item.Update();
        }
    }
}
