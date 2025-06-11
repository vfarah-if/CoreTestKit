namespace OrnateStatueStore;

public partial class Store
{
    private class AgedBrieUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            UpdateAgedBrie(item);
            item.ReduceSellInByADay();
            if (item.SellIn < 0) UpdatedAgedBrieWhenExpired(item);
        }
    }

    private static void UpdatedAgedBrieWhenExpired(Item item)
    {
        item.IncreaseQuality();
    }

    private static void UpdateAgedBrie(Item item)
    {
        item.IncreaseQuality();
    }
}