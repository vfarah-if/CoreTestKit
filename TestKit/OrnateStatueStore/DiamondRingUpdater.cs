namespace OrnateStatueStore;

public class DiamondRingUpdater : IItemUpdater
{
    public void Update(Item item)
    {
        item.Quality = 80;
    }
}
