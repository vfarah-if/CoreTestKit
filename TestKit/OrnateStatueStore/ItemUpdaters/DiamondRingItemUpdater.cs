namespace OrnateStatueStore.ItemUpdaters;

public class DiamondRingItemUpdater : IItemUpdater
{
    public void Update(Item item)
    {
        item.Quality = 80;
    }
}
