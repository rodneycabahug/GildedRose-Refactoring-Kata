using System;

namespace GildedRoseKata;

public class ConjuredItem : Item, IUpdatable, ICreatable<ConjuredItem>
{
    private const string ConjuredItemNamePrefix = "Conjured";

    private ConjuredItem(string name, int sellIn, int quality)
    {
        Name = name;
        SellIn = sellIn;
        Quality = quality;
    }

    public static bool IsConjuredItem(string name)
    {
        return name.StartsWith(ConjuredItemNamePrefix);
    }

    public static ConjuredItem Create(string name, int sellIn, int quality)
    {
        if (IsConjuredItem(name) == false)
        {
            throw new ArgumentException($"Name must start with '{ConjuredItemNamePrefix}'.");
        }

        if (quality < 0 || quality > 50)
        {
            throw new ArgumentException("Quality must be between 0 and 50, inclusive.");
        }

        return new ConjuredItem(name, sellIn, quality);
    }

    public void Update()
    {
        SellIn--;
        Quality = Math.Max(SellIn < 0 ? Quality - 4 : Quality - 2, 0);
    }
}
