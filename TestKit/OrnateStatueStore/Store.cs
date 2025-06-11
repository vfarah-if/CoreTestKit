namespace OrnateStatueStore;

public partial class Store
{
    private readonly IList<Item> _items;

    public Store(IList<Item> items)
    {
        _items = items;
    }
    public void UpdateQuality()
    {
        var itemUpdaters = new Dictionary<string, IItemUpdater>()
        {
            ["Aged Brie"] = new AgedBrieUpdater(),
            ["Backstage passes to concert"] = new BackstagePassesUpdater(),
            ["Fresh apples"] = new FreshApplesUpdater(),
            ["Diamond ring"] = new DiamondRingUpdater(),
        };
        foreach (var item in _items)
        {
            var updater = itemUpdaters.TryGetValue(item.Name, out var itemUpdater) ? itemUpdater : new DefaultItemUpdater();
            updater.Update(item);
            // UpdateItem(item);
        }
    }

    // private static void UpdateItem(Item item)
    // {
    //     if (item.Name == "Diamond ring") return;
    //     UpdateQualityBeforeSellInChanges(item);
    //     item.ReduceSellInByADay();
    //     UpdateQualityAfterSellInExpires(item);
    // }

    // private static void UpdateQualityBeforeSellInChanges(Item item)
    // {
    //     switch (item.Name)
    //     {
    //         case "Aged Brie":
    //             UpdateAgedBrie(item);
    //             break;
    //         case "Backstage passes to concert":
    //             UpdateBackstagePassesQuality(item);
    //             break;
    //         case "Fresh apples":
    //             UpdateFreshApples(item);
    //             break;
    //         default:
    //             UpdateDefault(item);
    //             break;
    //     }
    // }

    // private static void UpdateQualityAfterSellInExpires(Item item)
    // {
    //     if (item.SellIn >= 0) return;
    //     switch (item.Name)
    //     {
    //         case "Aged Brie":
    //             UpdatedAgedBrieWhenExpired(item);
    //             return;
    //         case "Backstage passes to concert":
    //             UpdateExpiredConcert(item);
    //             break;
    //         case "Fresh apples":
    //             UpdateExpiredFreshApples(item);
    //             break;
    //         default:
    //             UpdateDefaultExpiredItem(item);
    //             return;
    //     }
    // }

    private static void UpdateExpiredConcert(Item item)
    {
        item.Quality = 0;
    }

    private static void UpdatedAgedBrieWhenExpired(Item item)
    {
        item.IncreaseQuality();
    }

    private static void UpdateDefault(Item item)
    {
        item.ReduceQuality();
    }

    private static void UpdateAgedBrie(Item item)
    {
        item.IncreaseQuality();
    }

    private static void UpdateBackstagePassesQuality(Item item)
    {
        item.IncreaseQuality();

        if (item.SellIn < 11)
        {
            item.IncreaseQuality();
        }

        if (item.SellIn < 6)
        {
            item.IncreaseQuality();
        }
    }
}
