namespace OrnateStatueStore;

public partial class Store
{
    public class DefaultItemUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            UpdateDefault(item);
            item.ReduceSellInByADay();
            if (item.SellIn < 0)
            {
                UpdateDefaultExpiredItem(item);
            }
        }
    }

    private static void UpdateDefaultExpiredItem(Item item)
    {
        item.ReduceQuality();
    }
}