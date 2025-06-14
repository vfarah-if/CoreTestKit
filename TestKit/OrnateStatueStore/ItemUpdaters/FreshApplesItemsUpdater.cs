namespace OrnateStatueStore.ItemUpdaters;

public class FreshApplesItemsUpdater : IItemUpdater
{
    public void Update(Item item)
    {
        UpdateFreshApples(item);
        item.ReduceSellInByADay();
        if (item.SellIn < 0)
        {
            UpdateExpiredFreshApples(item);
        }
    }

    private static void UpdateExpiredFreshApples(Item item)
    {
        item.ReduceQuality(2);
    }

    private static void UpdateFreshApples(Item item)
    {
        item.ReduceQuality(2);
    }
}