using GildedRose.Console.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.Services
{
    public class QualityService : IQualityService
    {
        private readonly IProductService _productService;

        public QualityService(IProductService productService)
        {
            _productService = productService;
        }

        public IList<Product> UpdateQuality()
        {
            var products = new List<Product>(_productService.GetAllProduct());

            System.Console.WriteLine("NewUpdateProcess");

            foreach (var elem in products)
            {
                elem.SellIn--;

                if (!elem.IsAged)
                {
                    elem.Quality = elem.Quality == 0 ? elem.Quality : elem.Quality - 1;

                    elem.Quality = (elem.SellIn < 0 && elem.Quality > 0) ? elem.Quality - 1 : elem.Quality;
                }
                else
                {
                    elem.Quality = elem.Quality == 50 ? elem.Quality : elem.Quality + 1;

                    elem.Quality = (elem.SellIn < 0 && elem.Quality < 50) ? elem.Quality + 1 : elem.Quality;
                }

                elem.Price = Math.Round(elem.Quality * 1.9M, 2);
            }

            return products.ToList();
        }        
    }
}
