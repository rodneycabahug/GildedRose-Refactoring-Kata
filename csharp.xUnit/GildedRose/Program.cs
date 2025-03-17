using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("OMGHAI!");

        IList<Item> items = new List<Item>
        {
            CommonItem.Create(name: "+5 Dexterity Vest", sellIn: 10, quality: 20),
            AgedBrie.Create(name: "Aged Brie", sellIn: 2, quality: 0),
            CommonItem.Create(name: "Elixir of the Mongoose", sellIn: 5, quality: 7),
            Sulfuras.Create(name: "Sulfuras, Hand of Ragnaros", sellIn: 0, quality: 80),
            Sulfuras.Create(name: "Sulfuras, Hand of Ragnaros", sellIn: -1, quality: 80),
            BackstagePass.Create(name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 15, quality: 20),
            BackstagePass.Create(name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 10, quality: 49),
            BackstagePass.Create(name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 5, quality: 49),
            ConjuredItem.Create(name: "Conjured Mana Cake", sellIn: 3, quality: 6)
        };

        var app = new GildedRose(items);

        int days = 2;
        if (args.Length > 0)
        {
            days = int.Parse(args[0]) + 1;
        }

        for (var i = 0; i < days; i++)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");
            for (var j = 0; j < items.Count; j++)
            {
                Console.WriteLine(items[j].Name + ", " + items[j].SellIn + ", " + items[j].Quality);
            }
            Console.WriteLine("");
            app.UpdateQuality();
        }
    }
}