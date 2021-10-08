﻿using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aula05.GildedRose.UnitTests
{
    public class GildedRoseTests
    {        
        private Item CriarSulfuras(int quality, int sellin)
        {
            var item = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                Quality = quality,
                SellIn = sellin
            };

            return item;
        }

        private GildedRose CriarGildRose(Item item)
        {
            return new GildedRose(new List<Item> { item });
        }

        [Fact]
        [Trait("UpdateQuality", "Sulfuras")]
        public void UpdateQuality_ItemSulfuras_NuncaAlteraSellIn()
        {
            //arrange
            var item = new SulfurasBuilder(-1).Build();                

            var items = new List<Item>() { item };
            var gildedRose = new GildedRose(items);

            //act
            gildedRose.UpdateQuality();

            //assert
            item.SellIn.Should().Be(-1);
        }

        [Fact]
        [Trait("UpdateQuality", "Sulfuras")]
        public void UpdateQuality_ItemSulfuras_NuncaCaiQualidade()
        {
            //arrange
            var item = CriarSulfuras(80, -1);

            var items = new List<Item>() { item };
            var gildedRose = new GildedRose(items);

            //act
            gildedRose.UpdateQuality();

            //assert
            item.Quality.Should().Be(80);
        }

        public static IEnumerable<object[]> ItensEspeciais =>
        new List<object[]>
        {
            new object[] { new Item { Name = "Aged Brie", Quality = 50, SellIn = 10 }, 9 },
            new object[] { new Item { Name = "Aged Brie", Quality = 50, SellIn = -1 }, -2 },
            new object[] { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", 
                Quality = 50, 
                SellIn = 11 }, 10 },
            new object[] { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", 
                Quality = 50, 
                SellIn = 10 }, 9 },
            new object[] { new Item { Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = 50,
                SellIn = 5 }, 4 },
        };

        [Theory]
        [MemberData(nameof(ItensEspeciais))]
        public void UpdateQuality_ItemAgedBrieOuBacktageQualidade50_QualidadeNaoAltera(Item item, int sellInEsperado)
        {
            var gildedRose = CriarGildRose(item);

            //act
            gildedRose.UpdateQuality();

            //assert
            item.Quality.Should().Be(50);
            item.SellIn.Should().Be(sellInEsperado);
        }

        [Theory]
        [InlineData(2,-1,4,-2)]
        [InlineData(3, -2, 5, -3)]              
        public void UpdateQuality_ItemAgedBrieSellInMenorQueZero_QualidadeSobeDuasUnidadesMaximo50(int quality,
            int sellIn,
            int qualityEsperado,
            int sellInEsperado)
        {
            //arrange
            var item = new Item
            {
                Name = "Aged Brie",
                Quality = quality,
                SellIn = sellIn
            };

            var gildedRose = CriarGildRose(item);

            //act
            gildedRose.UpdateQuality();

            //assert
            item.Quality.Should().Be(qualityEsperado);
            item.SellIn.Should().Be(sellInEsperado);
        }

        [Theory]
        [InlineData(2, 2, 3, 1)]
        [InlineData(2, 1, 3, 0)]        
        public void UpdateQuality_ItemAgedBrieSellInMaiorOuIgualAZero_QualidadeSobeUmaUnidadeMaximo50(
            int quality, 
            int sellIn, 
            int qualityEsperado,
            int sellInEsperado)
        {
            //arrange
            var item = new Item
            {
                Name = "Aged Brie",
                Quality = quality,
                SellIn = sellIn
            };

            var gildedRose = CriarGildRose(item);

            //act
            gildedRose.UpdateQuality();

            //assert
            item.Quality.Should().Be(qualityEsperado);
            item.SellIn.Should().Be(sellInEsperado);
        }

        [Theory]
        [InlineData(2,11,3,10)]
        [InlineData(2, 12, 3, 11)]
        public void UpdateQuality_ItemBackstageSellInMaiorQue10_QualidadeSobeUmaUnidadeMaximo50(
            int quality,
            int sellIn,
            int qualityEsperado,
            int sellInEsperado)
        {
            //arrange
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = quality,
                SellIn = sellIn
            };

            var gildedRose = CriarGildRose(item);

            //act
            gildedRose.UpdateQuality();

            //assert
            item.Quality.Should().Be(qualityEsperado);
            item.SellIn.Should().Be(sellInEsperado);
        }

        [Theory]
        [InlineData(2, 10, 4, 9)]
        [InlineData(2, 6, 4, 5)]
        public void UpdateQuality_ItemBackstageSellInMenorOuIgualA10MaiorQue5_QualidadeSobeDuasUnidadesMaximo50(
            int quality,
            int sellIn,
            int qualityEsperado,
            int sellInEsperado)
        {
            //arrange
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = quality,
                SellIn = sellIn
            };

            var gildedRose = CriarGildRose(item);

            //act
            gildedRose.UpdateQuality();

            //assert
            item.Quality.Should().Be(qualityEsperado);
            item.SellIn.Should().Be(sellInEsperado);
        }


        [Theory]        
        [InlineData(2, 5, 5, 4)]
        [InlineData(2, 4, 5, 3)]
        public void UpdateQuality_ItemBackstageSellInMenorOuIgualA5_QualidadeSobe3UnidadesMaximo50(
            int quality,
            int sellIn,
            int qualityEsperado,
            int sellInEsperado)
        {
            //arrange
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = quality,
                SellIn = sellIn
            };

            var gildedRose = CriarGildRose(item);

            //act
            gildedRose.UpdateQuality();

            //assert
            item.Quality.Should().Be(qualityEsperado);
            item.SellIn.Should().Be(sellInEsperado);
        }
    }
}
