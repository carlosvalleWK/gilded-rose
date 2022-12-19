using GildedRose.Console.Entities;
using GildedRose.Console.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GildedRose.Console.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool CreateProduct(Product product)
        {
            return _productRepository.CreateProduct(product);
        }

        public IList<Product> GetAllProduct()
        {
            return _productRepository.GetAllProduct();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public Product GetProductByName(string name)
        {
            return _productRepository.GetProductByName(name);
        }

        public bool UpdateProduct(Product product)
        {
            return _productRepository.UpdateProduct(product);
        }

        public bool DeleteProduct(int id)
        {
            return _productRepository.DeleteProduct(id);
        }
    }
}
