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
}
