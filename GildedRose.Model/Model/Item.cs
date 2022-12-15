using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GildedRose.Model.Model
{
    [Serializable]
    public class Item
    {
        public Item(string name, int quality, bool agesGood,int sellIn)
        {
            Name = name;
            Quality = quality;
            AgesGood = agesGood;
            Expired = false;
            SellIn = sellIn;
            Price = Math.Round(Quality * 1.9M, 2);
        }
        public string Name { get; init; }
        [Range(1, int.MaxValue)]
        public int SellIn { get; private set; }
        [Range(1, 50)]
        public int Quality { get; private set; }
        public decimal Price { get; private set; }
        public bool AgesGood { get; private init; }
        public bool Expired { get; private set; }

        //Se actualiza el número de días de vida
        private void UpdateSellIn(int sellInVariation)
        {
            if (SellIn > sellInVariation)
                SellIn -= sellInVariation;
            else
                SellIn = 0;

            if (SellIn == 0)
                Expired = true;
        }

        //Se actualiza la calidad
        private void UpdateQuality(int qualityVariation)
        {
            if (AgesGood)
            {
                if (Quality + qualityVariation <= 50)
                    Quality += qualityVariation;
                else
                    Quality = 50;
            }
            else
            {
                if (Expired)
                    qualityVariation *= 2;
                if(Quality- qualityVariation >= 0)
                    Quality -= qualityVariation;
                else
                    Quality = 0;
            }

        }

        private void UpdatePrice(decimal qualityPriceFactor)
        {
            this.Price = Math.Round(Quality * qualityPriceFactor, 2);
        }

        public void UpdateProduct(int sellInVariation, int qualityVariation, decimal qualityPriceFactor)
        {
            UpdateSellIn(sellInVariation);
            UpdateQuality(qualityVariation);
            UpdatePrice(qualityPriceFactor);
        }

    }

}
