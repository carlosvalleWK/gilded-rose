using GildedRose.Application.Contracts.Products;
using GildedRose.Domain.Products;

namespace GildedRose.Application.Features.Products
{
    public class ProductsManager : IProductsManager
    {
        public IEnumerable<Product> SetValues(IEnumerable<Product> items)
        {
            foreach (Product item in items!)
            {
                item.SetSellIn();
                item.SetQuality();
                item.SetPrice();
            }
            return items;
        }
    }
}
