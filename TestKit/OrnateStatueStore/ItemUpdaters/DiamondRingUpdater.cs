namespace OrnateStatueStore.ItemUpdaters;

public class DiamondRingUpdater : IItemUpdater
{
    public void Update(Item item)
    {
        item.Quality = 80;
    }
}
