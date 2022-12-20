﻿using GildedRose.Console.Services;
using System;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        private const decimal PriceCalculateConst = 1.9M;
        private const string AgedBrieItemName = "Aged Brie";
        public IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7}
                }
            };

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var qualityCalculateStrategy = GetQualityCalculateStrategy(item);

                item.Quality = qualityCalculateStrategy.CalculateNewQuality(item.Quality);

                item.SellIn--;

                if (item.SellIn < 0)
                {
                    item.Quality = qualityCalculateStrategy.CalculateNewQuality(item.Quality);
                }
                item.Price = CalulatePrice(item.Quality);
            }
        }

        private static IQualityCalculateStrategy GetQualityCalculateStrategy(Item item)
        {
            IQualityCalculateStrategy qualityCalculateStrategy = new QualityDegradeStrategy();
            if (item.Name == AgedBrieItemName)
            {
                qualityCalculateStrategy = new QualityIncreaseStrategy();
            }

            return qualityCalculateStrategy;
        }

        public decimal CalulatePrice(int quality)
        {
            return Math.Round(quality * PriceCalculateConst, 2);
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public decimal Price { get; set; }
    }
}
