using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula05.GildedRose.UnitTests
{
    public class ItemBuilder
    {
        protected Item _item;

        public ItemBuilder() 
        {
            _item = new Item();
        }

        public ItemBuilder ComNome(string name)
        {
            _item.Name = name;
            return this;
        }

        public virtual ItemBuilder ComQualidade(int qualidade)
        {
            _item.Quality = qualidade;
            return this;
        }

        public ItemBuilder ComSellIn(int sellIn)
        {
            _item.SellIn = sellIn;
            return this;
        }

        public Item Build()
        {
            return _item;
        }
    }
}
