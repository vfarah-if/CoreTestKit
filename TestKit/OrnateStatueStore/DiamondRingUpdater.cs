namespace OrnateStatueStore;

public partial class Store
{
    public class DiamondRingUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            item.Quality = 80;
        }
    }
}