using GildedRose.Console.Entities;
using GildedRose.Console.Repository;
using GildedRose.Console.Services;
using GildedRose.Console.Services.Quality;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace UnitTestProject_GildedRoseConsole
{
    [TestClass]
    public class QualityCalculationTest
    {
        [TestMethod]
        public void TestComparingUpdateQuality()
        {
            var productRepository = new ProductRepository();
            var productService = new ProductService(productRepository);
            var qualityService = new QualityService(productService);
            var oldQualityService = new OldQualityService(productService);

            var expectedProducts = oldQualityService.UpdateQualityOldProcess();
            var newProducts = qualityService.UpdateQuality();

            for (int i = 0; i < expectedProducts.Count; i++)
            {
                Assert.AreEqual(expectedProducts[i].GetHashCode(), newProducts[i].GetHashCode());
            }
        }

        [TestMethod]
        public void TestAgedProducts()
        {
            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository.Setup(m => m.GetAllProduct()).Returns(
                new List<Product> {
                    new Product {
                        Id = 1,
                        Name = "Roquefort",
                        SellIn = 0,
                        Quality = 50,
                        IsAged = true
                    },
                    new Product {
                        Id = 2,
                        Name = "Aged Brie",
                        SellIn = 2,
                        Quality = 4,
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
                        Name = "Queso Azul",
                        SellIn = 0,
                        Quality = 49,
                        IsAged = true
                    }
                }
            );

            var productService = new ProductService(mockProductRepository.Object);
            var qualityService = new QualityService(productService);
            var oldQualityService = new OldQualityService(productService);

            var expectedProducts = oldQualityService.UpdateQualityOldProcess();
            var newProducts = qualityService.UpdateQuality();

            for (int i = 0; i < expectedProducts.Count; i++)
            {
                Assert.AreEqual(expectedProducts[i].GetHashCode(), newProducts[i].GetHashCode());
            }
        }

        [TestMethod]
        public void TestNormalProducts()
        {
            // ARRANGE
            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository.Setup(m => m.GetAllProduct()).Returns(
                new List<Product> {
                    new Product {
                        Id = 1,
                        Name = "Empanadas",
                        SellIn = -5,
                        Quality = 3,
                        IsAged = false
                    },
                    new Product {
                        Id = 2,
                        Name = "Dulce de leche",
                        SellIn = 2,
                        Quality = 4,
                        IsAged = false
                    },
                    new Product {
                        Id = 3,
                        Name = "Yerba",
                        SellIn = 10,
                        Quality = 2,
                        IsAged = false
                    },
                    new Product {
                        Id = 4,
                        Name = "Alfajores",
                        SellIn = 2,
                        Quality = 0,
                        IsAged = false
                    }
                }
            );

            var productService = new ProductService(mockProductRepository.Object);
            var qualityService = new QualityService(productService);
            var oldQualityService = new OldQualityService(productService);

            var expectedProducts = oldQualityService.UpdateQualityOldProcess();
            var newProducts = qualityService.UpdateQuality();

            for (int i = 0; i < expectedProducts.Count; i++)
            {
                Assert.AreEqual(expectedProducts[i].GetHashCode(), newProducts[i].GetHashCode());
            }
        }
    }
}
