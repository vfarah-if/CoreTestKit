namespace OrnateStatueStore;

public static class ItemExtension
{
    public static void IncreaseQuality(this Item item, int amount = 1)
    {
        item.Quality = Math.Min(50, item.Quality + amount);
    }

    public static void ReduceSellInByADay(this Item item)
    {
        item.SellIn -= 1;
    }

    public static void ReduceQuality(this Item item, int amount = 1)
    {
        item.Quality = Math.Max(0, item.Quality - amount);
    }
}