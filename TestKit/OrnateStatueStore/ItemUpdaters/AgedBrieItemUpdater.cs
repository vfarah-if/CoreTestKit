namespace OrnateStatueStore.ItemUpdaters;

public class AgedBrieItemUpdater : IItemUpdater
{
    public void Update(Item item)
    {
        UpdateAgedBrie(item);
        item.ReduceSellInByADay();
        if (item.SellIn < 0) UpdateAgedBrie(item);
    }

    private static void UpdateAgedBrie(Item item)
    {
        item.IncreaseQuality();
    }
}
