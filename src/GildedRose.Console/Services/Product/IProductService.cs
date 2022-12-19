using GildedRose.Console.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.Services
{
    public interface IProductService
    {
        bool CreateProduct(Product product);
        IList<Product> GetAllProduct();
        Product GetProductById(int id);
        Product GetProductByName(string name);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);
    }
}
