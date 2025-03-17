using System;

namespace GildedRoseKata;

public class BackstagePass : Item, IUpdatable, ICreatable<BackstagePass>
{
    private const string BackstagePassNamePrefix = "Backstage passes";

    private BackstagePass(string name, int sellIn, int quality)
    {
        Name = name;
        SellIn = sellIn;
        Quality = quality;
    }

    public static bool IsBackstagePass(string name)
    {
        return name.StartsWith(BackstagePassNamePrefix);
    }

    public static BackstagePass Create(string name, int sellIn, int quality)
    {
        if (IsBackstagePass(name) == false)
        {
            throw new ArgumentException($"Name must start with '{BackstagePassNamePrefix}'.");
        }

        if (quality < 0 || quality > 50)
        {
            throw new ArgumentException("Quality must be between 0 and 50, inclusive.");
        }

        return new BackstagePass(name, sellIn, quality);
    }

    public void Update()
    {
        SellIn--;

        if (SellIn < 0)
        {
            Quality = 0;
            return;
        }

        Quality = Math.Min(Quality + (SellIn < 5 ? 3 : SellIn < 10 ? 2 : 1), 50);
    }
}
