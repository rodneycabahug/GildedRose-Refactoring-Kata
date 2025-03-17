using Xunit;
using GildedRoseKata;
using System;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void CommonItem_Create_CreatesItem()
    {
        var item = CommonItem.Create("Rock", 0, 0);
        Assert.Equal("Rock", item.Name);
        Assert.Equal(0, item.SellIn);
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void CommonItem_Create_ValidatesName()
    {
        Assert.Throws<ArgumentException>(() => CommonItem.Create("Sulfuras, Hand of Ragnaros", 0, 80));
        Assert.Throws<ArgumentException>(() => CommonItem.Create("Aged Brie", 0, 40));
        Assert.Throws<ArgumentException>(() => CommonItem.Create("Backstage passes XYZ", 0, 30));
        Assert.Throws<ArgumentException>(() => CommonItem.Create("Conjured Mana Cake", 0, 30));
    }

    [Fact]
    public void CommonItem_Create_ValidatesQuality()
    {
        Assert.Throws<ArgumentException>(() => CommonItem.Create("Rock", 0, -1));
        Assert.Throws<ArgumentException>(() => CommonItem.Create("Rock", 0, 51));
    }

    [Fact]
    public void CommonItem_Update_DecreasesQualityAndSellIn()
    {
        var item = CommonItem.Create("Rock", 1, 1);
        item.Update();
        Assert.Equal(0, item.SellIn);
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void CommonItem_Update_QualityNeverNegative()
    {
        var item = CommonItem.Create("Rock", 1, 0);
        item.Update();
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void CommonItem_Update_QualityDecreasesTwiceAfterSellIn()
    {
        var item = CommonItem.Create("Rock", 0, 2);
        item.Update();
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void AgedBrie_Create_CreatesAgedBrie()
    {
        var agedBrie = AgedBrie.Create("Aged Brie", 0, 0);
        Assert.Equal("Aged Brie", agedBrie.Name);
        Assert.Equal(0, agedBrie.SellIn);
        Assert.Equal(0, agedBrie.Quality);
    }

    [Fact]
    public void AgedBrie_Create_ValidatesName()
    {
        Assert.Throws<ArgumentException>(() => AgedBrie.Create("Some item", 0, 0));
    }

    [Fact]
    public void AgedBrie_Create_ValidatesQuality()
    {
        Assert.Throws<ArgumentException>(() => AgedBrie.Create("Aged Brie", 0, -1));
        Assert.Throws<ArgumentException>(() => AgedBrie.Create("Aged Brie", 0, 51));
    }

    [Fact]
    public void AgedBrie_Update_IncreasesQuality()
    {
        var agedBrie = AgedBrie.Create("Aged Brie", 1, 0);
        agedBrie.Update();
        Assert.Equal(1, agedBrie.Quality);
    }

    [Fact]
    public void AgedBrie_Update_QualityNeverMoreThan50()
    {
        var agedBrie = AgedBrie.Create("Aged Brie", 1, 50);
        agedBrie.Update();
        Assert.Equal(50, agedBrie.Quality);
    }

    [Fact]
    public void AgedBrie_Update_IncreasesQualityTwiceAfterSellIn()
    {
        var agedBrie = AgedBrie.Create("Aged Brie", 0, 0);
        agedBrie.Update();
        Assert.Equal(2, agedBrie.Quality);
    }

    [Fact]
    public void BackstagePass_Create_CreatesBackstagePass()
    {
        var backstagePass = BackstagePass.Create("Backstage passes to a TAFKAL80ETC concert", 0, 0);
        Assert.Equal("Backstage passes to a TAFKAL80ETC concert", backstagePass.Name);
        Assert.Equal(0, backstagePass.SellIn);
        Assert.Equal(0, backstagePass.Quality);
    }

    [Fact]
    public void BackstagePass_Create_ValidatesName()
    {
        Assert.Throws<ArgumentException>(() => BackstagePass.Create("Some item", 0, 0));
    }

    [Fact]
    public void BackstagePass_Create_ValidatesQuality()
    {
        Assert.Throws<ArgumentException>(() => BackstagePass.Create("Backstage passes to a TAFKAL80ETC concert", 0, -1));
        Assert.Throws<ArgumentException>(() => BackstagePass.Create("Backstage passes to a TAFKAL80ETC concert", 0, 51));
    }

    [Fact]
    public void BackstagePass_Update_IncreasesQuality()
    {
        var backstagePass = BackstagePass.Create("Backstage passes to a TAFKAL80ETC concert", 11, 0);
        backstagePass.Update();
        Assert.Equal(1, backstagePass.Quality);
    }

    [Fact]
    public void BackstagePass_Update_IncreasesQualityBy2WhenSellInLessThan10()
    {
        var backstagePass = BackstagePass.Create("Backstage passes to a TAFKAL80ETC concert", 10, 0);
        backstagePass.Update();
        Assert.Equal(2, backstagePass.Quality);
    }

    [Fact]
    public void BackstagePass_Update_IncreasesQualityBy3WhenSellInLessThan5()
    {
        var backstagePass = BackstagePass.Create("Backstage passes to a TAFKAL80ETC concert", 5, 0);
        backstagePass.Update();
        Assert.Equal(3, backstagePass.Quality);
    }

    [Fact]
    public void BackstagePass_Update_QualityIs0AfterSellIn()
    {
        var backstagePass = BackstagePass.Create("Backstage passes to a TAFKAL80ETC concert", 0, 10);
        backstagePass.Update();
        Assert.Equal(0, backstagePass.Quality);
    }

    [Fact]
    public void BackstagePass_Update_QualityNeverMoreThan50()
    {
        var backstagePass = BackstagePass.Create("Backstage passes to a TAFKAL80ETC concert", 11, 50);
        backstagePass.Update();
        Assert.Equal(50, backstagePass.Quality);
    }

    [Fact]
    public void Sulfuras_Create_ValidatesName()
    {
        Assert.Throws<ArgumentException>(() => Sulfuras.Create("Some item", 0, 80));
    }

    [Fact]
    public void Sulfuras_Create_ValidatesQuality()
    {
        Assert.Throws<ArgumentException>(() => Sulfuras.Create("Sulfuras, Hand of Ragnaros", 0, 79));
    }

    [Fact]
    public void Sulfuras_Create_CreatesSulfuras()
    {
        var sulfuras = Sulfuras.Create("Sulfuras, Hand of Ragnaros", 0, 80);
        Assert.Equal("Sulfuras, Hand of Ragnaros", sulfuras.Name);
        Assert.Equal(0, sulfuras.SellIn);
        Assert.Equal(80, sulfuras.Quality);
    }

    [Fact]
    public void Sulfuras_Update_KeepsQualityAt80()
    {
        var sulfuras = Sulfuras.Create("Sulfuras, Hand of Ragnaros", 0, 80);
        sulfuras.Update();
        Assert.Equal(80, sulfuras.Quality);
    }

    [Fact]
    public void Sulfuras_Update_KeepsSellIn()
    {
        var sulfuras = Sulfuras.Create("Sulfuras, Hand of Ragnaros", 0, 80);
        sulfuras.Update();
        Assert.Equal(0, sulfuras.SellIn);
    }

    [Fact]
    public void ConjuredItem_Create_CreatesConjuredItem()
    {
        var conjuredItem = ConjuredItem.Create("Conjured Mana Cake", 0, 0);
        Assert.Equal("Conjured Mana Cake", conjuredItem.Name);
        Assert.Equal(0, conjuredItem.SellIn);
        Assert.Equal(0, conjuredItem.Quality);
    }

    [Fact]
    public void ConjuredItem_Create_ValidatesName()
    {
        Assert.Throws<ArgumentException>(() => ConjuredItem.Create("Some item", 0, 0));
    }

    [Fact]
    public void ConjuredItem_Create_ValidatesQuality()
    {
        Assert.Throws<ArgumentException>(() => ConjuredItem.Create("Conjured Mana Cake", 0, -1));
        Assert.Throws<ArgumentException>(() => ConjuredItem.Create("Conjured Mana Cake", 0, 51));
    }

    [Fact]
    public void ConjuredItem_Update_DecreasesQualityBy2()
    {
        var conjuredItem = ConjuredItem.Create("Conjured Mana Cake", 1, 2);
        conjuredItem.Update();
        Assert.Equal(0, conjuredItem.Quality);
    }
    
    [Fact]
    public void ConjuredItem_Update_DecreasesQualityBy4AfterSellIn()
    {
        var conjuredItem = ConjuredItem.Create("Conjured Mana Cake", 0, 4);
        conjuredItem.Update();
        Assert.Equal(0, conjuredItem.Quality);
    }
}