using System;

namespace GildedRoseKata;

public interface ICreatable<T> where T : Item
{
    static abstract T Create(string name, int sellIn, int quality);
}
