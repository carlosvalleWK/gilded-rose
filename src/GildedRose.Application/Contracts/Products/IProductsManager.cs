using GildedRose.Domain.Products;

namespace GildedRose.Application.Contracts.Products
{
    public interface IProductsManager
    {
        public IEnumerable<Product> SetValues(IEnumerable<Product> items);
    }
}
