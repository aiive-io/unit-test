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
        [Fact]
        public void UpdateQuality_ItemSulfuras_NuncaAlteraSellIn()
        {
            //arrange
            var item = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                Quality = 80,
                SellIn = -1
            };

            var items = new List<Item>() { item };
            var gildedRose = new GildedRose(items);

            //act
            gildedRose.UpdateQuality();

            //assert
            item.SellIn.Should().Be(-1);
        }


        [Fact]
        public void UpdateQuality_ItemSulfuras_NuncaCaiQualidade()
        {
            //arrange
            var item = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                Quality = 80,
                SellIn = 0
            };
            var items = new List<Item>() { item };
            var gildedRose = new GildedRose(items);

            //act
            gildedRose.UpdateQuality();

            //assert
            item.Quality.Should().Be(80);
        }
    }
}
