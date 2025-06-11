namespace OrnateStatueStore;

public partial class Store
{
    private partial class AgedBrieUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            UpdateAgedBrie(item);
            item.ReduceSellInByADay();
            if (item.SellIn < 0) UpdatedAgedBrieWhenExpired(item);
        }
    }
}