using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Models
{
    public class GenericItem : Item
    {
        protected override void updateQuality()
        {
            Quality = Quality > MIN_QUALITY ? Quality - 1 : MIN_QUALITY;
        }
    }
}

