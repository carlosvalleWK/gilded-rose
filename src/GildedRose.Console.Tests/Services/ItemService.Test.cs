using AutoFixture;
using GildedRose.Console.Models;
using GildedRose.Console.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GildedRose.Console.Tests
{


    public class ItemServiceTests
    {
        private readonly ItemService _sut;
        private readonly IFixture _fixture = new Fixture();

        public ItemServiceTests()
        {
            _sut = new ItemService();
        }

        [Fact]
        public void UpdateQuality_ShouldReduceSellIn_Allways()
        {
            //Arrange
            var baseSellIn = 99;
            var item = _fixture.Build<Item>()
                        .With(x => x.SellIn, baseSellIn)
                        .Create();

            _sut.Items = new List<Item>() { item };

            //Act
            _sut.UpdateItems();

            //Assert
            Assert.Equal(baseSellIn - 1, _sut.Items[0].SellIn);

        }


        [Fact]
        public void UpdateQuality_ShouldReduceQualityByOnce_WhenSellInIsGreaterThan1()
        {
            //Arrange
            var baseSellIn = 2;
            var baseQuality = 2;

            var item = _fixture.Build<Item>()
                        .With(x => x.SellIn, baseSellIn)
                        .With(x => x.Quality, baseQuality)
                        .Create();

            _sut.Items = new List<Item>() { item };

            //Act
            _sut.UpdateItems();

            //Assert
            Assert.Equal(baseQuality - 1, _sut.Items[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_ShouldMultipyQualityByConstant_WhenRecalcultatePrice()
        {
            //Arrange
            var baseSellIn = 2;
            var baseQuality = 2;

            var item = _fixture.Build<Item>()
                        .With(x => x.SellIn, baseSellIn)
                        .With(x => x.Quality, baseQuality)
                        .Create();

            var expectedPrice = Math.Round((baseQuality - 1) * 1.9M, 2);
            _sut.Items = new List<Item>() { item };

            //Act
            _sut.UpdateItems();

            //Assert

            Assert.Equal(expectedPrice, _sut.Items[0].Price);
        }

        [Fact]
        public void UpdateQuality_ShouldReduceQualityTwice_WhenSellInIsLowerThan2()
        {
            //Arrange
            var baseSellIn = 1;
            var baseQuality = 2;

            var item = _fixture.Build<Item>()
                        .With(x => x.SellIn, baseSellIn)
                        .With(x => x.Quality, baseQuality)
                        .Create();

            _sut.Items = new List<Item>() { item };

            //Act
            _sut.UpdateItems();

            //Assert
            Assert.Equal(baseQuality - 2, _sut.Items[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_ShouldentReduceQuality_WhenIs0()
        {
            //Arrange
            var baseQuality = 0;

            var item = _fixture.Build<Item>()
                        .With(x => x.Quality, baseQuality)
                        .Create();

            _sut.Items = new List<Item>() { item };

            //Act
            _sut.UpdateItems();

            //Assert
            Assert.Equal(baseQuality , _sut.Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_ShouldIncreaseQuality_WhenIsAgedBrie()
        {
            //Arrange
            var baseQuality = 3;

            var item = _fixture.Build<Item>()
                        .With(x => x.Quality, baseQuality)
                        .With(x => x.Name, "Aged Brie")
                        .Create();

            _sut.Items = new List<Item>() { item };

            //Act
            _sut.UpdateItems();

            //Assert
            Assert.Equal(baseQuality + 1 , _sut.Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_QualityIsNeverGreaterThan50()
        {
            //Arrange
            var baseQuality = 50;

            var item = _fixture.Build<Item>()
                        .With(x => x.Quality, baseQuality)
                        .With(x => x.Name, "Aged Brie")
                        .Create();

            _sut.Items = new List<Item>() { item };

            //Act
            _sut.UpdateItems();

            //Assert
            Assert.Equal(baseQuality, _sut.Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_ShouldDecreaseQulityTwice_IfSellInLowerThan0()
        {
            //Arrange
            var baseSellIn = -3;
            var baseQuality = 10;

            var item = _fixture.Build<Item>()
                        .With(x => x.SellIn, baseSellIn)
                        .With(x => x.Quality, baseQuality)
                        .Create();

            _sut.Items = new List<Item>() { item };

            //Act
            _sut.UpdateItems();

            //Assert
            Assert.Equal(baseQuality - 2, _sut.Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_ShouldIncreaseQulityTwice_IfSellInLowerThan0AndNameIsAged()
        {
            //Arrange
            var baseSellIn = -3;
            var baseQuality = 10;

            var item = _fixture.Build<Item>()
                        .With(x => x.SellIn, baseSellIn)
                        .With(x => x.Quality, baseQuality)
                        .With(x => x.Name, "Aged Brie")
                        .Create();

            _sut.Items = new List<Item>() { item };

            //Act
            _sut.UpdateItems();

            //Assert
            Assert.Equal(baseQuality + 2, _sut.Items[0].Quality);
        }

    }
}
