using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula05.GildedRose
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
    }

    public class Sulfuras: Item
    {
        public Sulfuras(int sellIn = 0)
        {
            Name = "Sulfuras, Hand of Ragnaros";
            SellIn = sellIn;
            Quality = 80;
        }
    }

    public class AgedBrie: Item
    {
        public AgedBrie(int sellIn, int quality)
        {
            SellIn = sellIn;
            Quality = quality;
        }

        public void UpdateQuality()
        {
            if (Quality == 50) return;
            
            SellIn -= 1;
            
            if(SellIn < 0)
            {
                Quality += 2;
            }
            else
            {
                Quality += 1;
            }
        }
    }
}
