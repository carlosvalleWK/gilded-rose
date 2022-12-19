using GildedRose.Data.Model;
using GildedRose.Data.Repository;
using System;
using System.Collections.Generic;

namespace GildedRose.Business
{
    public class ProductManagement
    {
        public const int PRODUCT_MAX_QUALITY = 50;
        public const int PRODUCT_MIN_QUALITY = 0;

        private readonly ProductRepository repository;
        public ProductManagement()
        {
            repository = new ProductRepository();
        }
        /// <summary>
        /// Updates product by end of day business logic
        /// </summary>
        public void UpdateEndOfDay()
        {
            IEnumerable<Product> products = repository.Get();

            foreach (Product product in products)
            {
                UpdateExpiration(product);
                UpdateByEndOfDay(product);
                UpdateByExpiration(product);
                UpdatePrice(product);

                Console.Write(product.ToString());
            };

            Console.Write("\n");

            repository.Update(products);
        }

        #region private
        /// <summary>
        /// Updates the product expiration date
        /// </summary>
        /// <param name="product"></param>
        private void UpdateExpiration(Product product)
        {
            product.SellIn--;
        }
        /// <summary>
        /// Updates the product proporties by End of Day Business Logic
        /// </summary>
        /// <param name="product"></param>
        private void UpdateByEndOfDay(Product product)
        {
            if (!product.IsSpecialItem)
            {
                if (product.Quality > PRODUCT_MIN_QUALITY)
                {
                    product.Quality--;
                }
            }
            else
            {
                if (product.Quality < PRODUCT_MAX_QUALITY)
                {
                    product.Quality++;
                }
            }
        }
        /// <summary>
        /// Updates product by Expiration Business logic
        /// </summary>
        /// <param name="product"></param>
        private void UpdateByExpiration(Product product)
        {
            if (product.IsExpired)
            {
                if (!product.IsSpecialItem)
                {

                    if (product.Quality > PRODUCT_MIN_QUALITY)
                    {
                        product.Quality--;
                    }
                }
                else
                {
                    if (product.Quality < PRODUCT_MAX_QUALITY)
                    {
                        product.Quality++;
                    }
                }
            }
        }
        /// <summary>
        /// Updates product price by business logic
        /// </summary>
        /// <param name="product"></param>
        private void UpdatePrice(Product product)
        {
            product.Price = Math.Round(product.Quality * 1.9M, 2);
        }
        #endregion
    }
}
