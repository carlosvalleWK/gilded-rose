using System.Collections.Generic;
using GildedRose.Console.Entities;

namespace GildedRose.Console.Repository
{
    public interface IProductRepository
    {
        bool CreateProduct(Product product);
        IList<Product> GetAllProduct();
        Product GetProductById(int id);
        Product GetProductByName(string name);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);
        bool Exists(int id);
    }
}
