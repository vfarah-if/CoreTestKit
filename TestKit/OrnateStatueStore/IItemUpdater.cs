namespace OrnateStatueStore;

public partial class Store
{
    public interface IItemUpdater
    {
        public void Update(Item item);
    }
}