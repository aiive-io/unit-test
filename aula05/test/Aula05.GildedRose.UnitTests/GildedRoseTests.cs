using FluentAssertions;
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

        [Theory]
        [InlineData(2,-1,4,-2)]
        [InlineData(3, -2, 5, -3)]      
        [InlineData(50, -1, 50, -2)]
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
        [InlineData(50, 1, 50, 0)]
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
        public void UpdateQuality_ItemBackstageSellInMaiorQue10_QualidadeSobeUmaUnidade(
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
