using GildedRose.Console.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GildedRose.Console.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> products = new List<Product> {
            new Product {
                Id = 1,
                Name = "+5 Dexterity Vest",
                SellIn = 10,
                Quality = 20,
                IsAged = false
            },
            new Product {
                Id = 2,
                Name = "Aged Brie",
                SellIn = 2,
                Quality = 0,
                IsAged = true
            },
            new Product {
                Id = 3,
                Name = "Extra-Aged Brie",
                SellIn = 0,
                Quality = 47,
                IsAged = true
            },
            new Product {
                Id = 4,
                Name = "Elixir of the Mongoose",
                SellIn = 0,
                Quality = 2,
                IsAged = false
            },
            new Product {
                Id = 5,
                Name = "Apple Juice",
                SellIn = 1,
                Quality = 7,
                IsAged = false
            }
        };

        public bool CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAllProduct()
        {
            return products.ToList();
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
