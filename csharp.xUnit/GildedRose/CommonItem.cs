using System;

namespace GildedRoseKata;

public class CommonItem : Item, IUpdatable, ICreatable<CommonItem>
{
    private CommonItem(string name, int sellIn, int quality)
    {
        Name = name;
        SellIn = sellIn;
        Quality = quality;
    }

    public static bool IsCommonItem(string name)
    {
        return Sulfuras.IsSulfuras(name) == false
            && AgedBrie.IsAgedBrie(name) == false
            && BackstagePass.IsBackstagePass(name) == false
            && ConjuredItem.IsConjuredItem(name) == false;
    }

    public static CommonItem Create(string name, int sellIn, int quality)
    {
        if (IsCommonItem(name) == false)
        {
            throw new ArgumentException($"'{name}' is not a name of a common item.");
        }

        if (quality < 0 || quality > 50)
        {
            throw new ArgumentException("Quality must be between 0 and 50, inclusive.");
        }

        return new CommonItem(name, sellIn, quality);
    }

    public virtual void Update()
    {
        SellIn--;
        Quality = Math.Max(SellIn < 0 ? Quality - 2 : Quality - 1, 0);
    }
}
