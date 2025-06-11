namespace OrnateStatueStore;

public partial class Store
{
    private readonly IList<Item> _items;
    private readonly Dictionary<string, IItemUpdater> _itemUpdaters = new()
    {
        ["Aged Brie"] = new AgedBrieUpdater(),
        ["Backstage passes to concert"] = new BackstagePassesUpdater(),
        ["Fresh apples"] = new FreshApplesUpdater(),
        ["Diamond ring"] = new DiamondRingUpdater(),
    };

    public Store(IList<Item> items)
    {
        _items = items;
    }
    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            var updater = _itemUpdaters.TryGetValue(item.Name, out var itemUpdater) ? itemUpdater : new DefaultItemUpdater();
            updater.Update(item);
        }
    }
}
