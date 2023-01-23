using Microsoft.Extensions.DependencyInjection;
using GildedRose.Application.Features.Products;
using GildedRose.Domain.Products;
using GildedRose.Application.Contracts.Products;

namespace GildedRose.Console
{
    public class Program
    {
        public IEnumerable<Product>? Products;

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Products = new List<Product>
                {
                    new Product { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                    new AgedBrieProduct { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                    new Product { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 }
                }
            };

            for (int i = 0; i < 30; i++)
            {
                app.Products = app.SetProductsValues(app.Products);
            }

            System.Console.ReadKey();
        }

        public IEnumerable<Product> SetProductsValues(IEnumerable<Product>? products)
        {
            IProductsManager productManager = GetProductsManager();
            return productManager.SetValues(products!);
        }

        private static IProductsManager GetProductsManager()
        {
            var serviceProvider = new ServiceCollection()
                        .AddSingleton<IProductsManager, ProductsManager>()
                        .BuildServiceProvider();

            return serviceProvider.GetService<IProductsManager>()!;
        }
    }
}