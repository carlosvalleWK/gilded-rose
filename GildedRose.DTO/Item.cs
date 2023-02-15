using System;

namespace GildedRose.DTO
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public decimal Price => Math.Round(Quality * 1.9M, 2);


        public bool IsAgedBrie => Name.Equals("Aged Brie");
        public bool IsMaxQuality => Quality >= 50;
        public bool IsMinQuality => Quality == 0;
        public bool IsExpired => SellIn == 0;
    }
}