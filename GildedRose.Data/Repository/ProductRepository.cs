using GildedRose.Data.Model;
using GildedRose.Data.Repository.Interface;
using System;
using System.Collections.Generic;

namespace GildedRose.Data.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private IEnumerable<Product> productData;
        public ProductRepository()
        {
            productData = new List<Product>()
            {
                new Product { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Product { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Product { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 }
            };
        }
        /// <summary>
        /// Gets a collection of Product
        /// </summary>
        /// <returns>Collection of Product</returns>
        public IEnumerable<Product> Get()
        {
            IEnumerable<Product> result = productData;

            return result;
        }
        /// <summary>
        /// Updates all products 
        /// </summary>
        /// <param name="products"></param>
        public void Update(IEnumerable<Product> products)
        {
            productData = products;
        }
    }
}
