using GildedRose.Console.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.Services.Quality
{
    public class OldQualityService : IOldQualityService
    {
        private readonly IProductService _productService;

        public OldQualityService(IProductService productService)
        {
            _productService = productService;
        }

        public IList<Product> UpdateQualityOldProcess()
        {
            var products = new List<Product>(_productService.GetAllProduct());

            System.Console.WriteLine("OldUpdateProcess");

            foreach (var elem in products)
            {
                if (!elem.IsAged)
                {
                    if (elem.Quality > 0)
                    {
                        elem.Quality = elem.Quality - 1;
                    }
                }
                else
                {
                    if (elem.Quality < 50)
                    {
                        elem.Quality = elem.Quality + 1;
                    }
                }

                elem.SellIn = elem.SellIn - 1;

                if (elem.SellIn < 0)
                {
                    if (!elem.IsAged)
                    {

                        if (elem.Quality > 0)
                        {
                            elem.Quality = elem.Quality - 1;
                        }
                    }
                    else
                    {
                        if (elem.Quality < 50)
                        {
                            elem.Quality = elem.Quality + 1;
                        }
                    }
                }

                elem.Price = Math.Round(elem.Quality * 1.9M, 2);
            }

            return products.ToList();
        }
    }
}
