using System;

namespace GildedRoseKata;

public class Sulfuras : Item, IUpdatable, ICreatable<Sulfuras>
{
    private const string SulfurasName = "Sulfuras, Hand of Ragnaros";

    private Sulfuras(int sellIn, int quality)
    {
        Name = SulfurasName;
        SellIn = sellIn;
        Quality = quality;
    }
    
    public static bool IsSulfuras(string name)
    {
        return name == SulfurasName;
    }

    public static Sulfuras Create(string name, int sellIn, int quality)
    {
        if (IsSulfuras(name) == false)
        {
            throw new ArgumentException("Name must be 'Sulfuras, Hand of Ragnaros'.");
        }

        if (quality != 80)
        {
            throw new ArgumentException("Quality must be 80.");
        }

        return new Sulfuras(sellIn, quality);
    }

    public void Update()
    {
        return;
    }
}
