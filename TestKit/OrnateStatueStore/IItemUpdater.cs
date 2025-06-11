namespace OrnateStatueStore;

public partial class Store
{
    public partial interface IItemUpdater
    {
        public void Update(Item item);
    }
}