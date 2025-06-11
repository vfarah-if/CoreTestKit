namespace OrnateStatueStore;

public partial class Store
{
    public class BackstagePassesUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            UpdateBackstagePassesQuality(item);
            item.ReduceSellInByADay();
            if (item.SellIn < 0) UpdateExpiredConcert(item);
        }
    }

    private static void UpdateExpiredConcert(Item item)
    {
        item.Quality = 0;
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