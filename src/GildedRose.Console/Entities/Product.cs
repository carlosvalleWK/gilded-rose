using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public decimal Price { get; set; }
        public bool IsAged { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Id == product.Id &&
                   Name == product.Name &&
                   SellIn == product.SellIn &&
                   Quality == product.Quality &&
                   Price == product.Price &&
                   IsAged == product.IsAged;
        }

        public override int GetHashCode()
        {
            int hashCode = -1596552084;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + SellIn.GetHashCode();
            hashCode = hashCode * -1521134295 + Quality.GetHashCode();
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            hashCode = hashCode * -1521134295 + IsAged.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "Id: " + this.Id +
                    "\nName: " + this.Name +
                    "\nSellIn: " + this.SellIn +
                    "\nQuality: " + this.Quality +
                    "\nPrice: " + this.Price +
                    "\nIsAged: " + this.IsAged;
        }
    }
}
