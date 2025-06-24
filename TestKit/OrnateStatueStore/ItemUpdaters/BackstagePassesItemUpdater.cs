namespace OrnateStatueStore.ItemUpdaters;

public class BackstagePassesItemUpdater : IItemUpdater
{
    public void Update(Item item)
    {
        UpdateBackstagePassesQuality(item);
        item.ReduceSellInByADay();
        if (item.SellIn < 0) UpdateExpiredConcert(item);
    }

    private static void UpdateExpiredConcert(Item item)
    {
        item.Quality = 0;
    }

    private static void UpdateBackstagePassesQuality(Item item)
    {
        switch (item.SellIn)
        {
            case > 10:
                item.IncreaseQuality();
                break;
            case > 5:
                item.IncreaseQuality(2);
                break;
            case > 0:
                item.IncreaseQuality(3);
                break;
            default:
                item.Quality = 0;
                break;
        }
    }
}

