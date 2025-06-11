namespace OrnateStatueStore;

public partial class Store
{
    public class BackstagePassesUpdater: IItemUpdater
    {
        public void Update(Item item)
        {
            UpdateBackstagePassesQuality(item);
            item.ReduceSellInByADay();
            if (item.SellIn < 0) UpdateExpiredConcert(item);
        }
    }
}