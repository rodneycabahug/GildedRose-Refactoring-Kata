using GildedRoseKata;

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using VerifyXunit;

using Xunit;

namespace GildedRoseTests;

public class ApprovalTest
{
    [Fact]
    public Task ConjuredItem()
    {
        Item[] items = [
            GildedRoseKata.ConjuredItem.Create("Conjured Mana Cake", 3, 6),
            GildedRoseKata.ConjuredItem.Create("Conjured Mana Cake", 0, 6),
            GildedRoseKata.ConjuredItem.Create("Conjured Mana Cake", 0, 3)
        ];
        GildedRose app = new(items);
        app.UpdateQuality();

        return Verifier.Verify(items);
    }

    [Fact]
    public Task AgedBrie()
    {
        Item[] items = [
            GildedRoseKata.AgedBrie.Create("Aged Brie", 0, 10),
            GildedRoseKata.AgedBrie.Create("Aged Brie", 0, 50),
            GildedRoseKata.AgedBrie.Create("Aged Brie", 1, 10)
        ];
        GildedRose app = new(items);
        app.UpdateQuality();

        return Verifier.Verify(items);
    }

    [Fact]
    public Task BackstagePasses()
    { 
        Item[] items = [
            BackstagePass.Create("Backstage passes to a TAFKAL80ETC concert", 15, 20),
            BackstagePass.Create("Backstage passes to a TAFKAL80ETC concert", 10, 49),
            BackstagePass.Create("Backstage passes to a TAFKAL80ETC concert", 5, 49)
        ];
        GildedRose app = new(items);
        app.UpdateQuality();

        return Verifier.Verify(items);
    }

    [Fact]
    public Task Sulfuras()
    {
        Item[] items = [
            GildedRoseKata.Sulfuras.Create("Sulfuras, Hand of Ragnaros", 0, 80)
        ];
        GildedRose app = new(items);
        app.UpdateQuality();

        return Verifier.Verify(items);
    }

    [Fact]
    public Task CommonItem()
    {
        Item[] items = [
            GildedRoseKata.CommonItem.Create("Rock", 0, 50)
        ];
        GildedRose app = new(items);
        app.UpdateQuality();

        return Verifier.Verify(items);
    }

    [Fact]
    public Task ThirtyDays()
    {
        var fakeoutput = new StringBuilder();
        Console.SetOut(new StringWriter(fakeoutput));
        Console.SetIn(new StringReader($"a{Environment.NewLine}"));

        Program.Main(["30"]);
        var output = fakeoutput.ToString();

        return Verifier.Verify(output);
    }
}