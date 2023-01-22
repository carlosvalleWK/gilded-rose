using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Models
{
    public class AgedItem : Item
    {
        protected override void updateQuality()
        {
            Quality = Quality < MAX_QUALITY ? Quality + 1 : MAX_QUALITY;
        }
    }
}
