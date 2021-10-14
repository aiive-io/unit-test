using System.Collections.Generic;

namespace Aula05.GildedRose
{
    public class GildedRose
    {
        const int QUALIDADEMAXIMA = 50;

        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        private bool EhItemEspecial(string nome)
        {
            var especiais = new List<string> { "Aged Brie", "Backstage passes to a TAFKAL80ETC concert" };

            return especiais.Contains(nome);
        }

        private bool EhBackstagePass(string nome)
        {
            return nome == "Backstage passes to a TAFKAL80ETC concert";
        }
 
        private bool EhAgedBrie(string nome)
        {
            return nome == "Aged Brie";
        }

        private bool EhConjured(string nome)
        {
            return nome == "Conjured Mana Cake";
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i] is Sulfuras) continue;
                
                if(Items[i] is AgedBrie item)
                {
                    item.UpdateQuality();
                }
                else
                {
                    if (EhBackstagePass(Items[i].Name))
                    {
                        if (Items[i].Quality < QUALIDADEMAXIMA)
                        {
                            Items[i].Quality = Items[i].Quality + 1;

                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < QUALIDADEMAXIMA)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < QUALIDADEMAXIMA)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }                            
                        }
                    }
                    else
                    {
                        if (Items[i].Quality > 0)
                        {
                            if (EhConjured(Items[i].Name))
                            {
                                Items[i].Quality = Items[i].Quality - 2;
                            }
                            else
                            {
                                Items[i].Quality = Items[i].Quality - 1;
                            }
                        }
                    }

                    Items[i].SellIn = Items[i].SellIn - 1;

                    if (Items[i].SellIn < 0)
                    {                                             
                        if (EhBackstagePass(Items[i].Name))
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                        else
                        {
                            if (Items[i].Quality > 0)
                            {
                                Items[i].Quality = Items[i].Quality - 1;
                            }
                        }                        
                    }
                }
            }
        }
    }
}
