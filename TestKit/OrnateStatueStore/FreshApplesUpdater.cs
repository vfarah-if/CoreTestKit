namespace OrnateStatueStore;

public partial class Store
{
    public class FreshApplesUpdater : IItemUpdater
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
    }
}