using System;

namespace GildedRoseKata;

public class AgedBrie : Item, IUpdatable, ICreatable<AgedBrie>
{
    private const string AgedBrieName = "Aged Brie";

    private AgedBrie(int sellIn, int quality)
    {
        Name = AgedBrieName;
        SellIn = sellIn;
        Quality = quality;
    }

    public static bool IsAgedBrie(string name)
    {
        return name == AgedBrieName;
    }

    public static AgedBrie Create(string name, int sellIn, int quality)
    {
        if (IsAgedBrie(name) == false)
        {
            throw new ArgumentException("Name must be 'Aged Brie'.");
        }

        if (quality < 0 || quality > 50)
        {
            throw new ArgumentException("Quality must be between 0 and 50, inclusive.");
        }

        return new AgedBrie(sellIn, quality);
    }

    public void Update()
    {
        SellIn--;
        Quality = Math.Min(SellIn < 0 ? Quality + 2 : Quality + 1, 50);
    }
}
