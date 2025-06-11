namespace OrnateStatueStore;

public class Store
{
    private readonly IList<Item> _items;

    public Store(IList<Item> items)
    {
        _items = items;
    }
    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            UpdateItem(item);
        }
    }

    private static void UpdateItem(Item item)
    {
        if (item.Name == "Diamond ring") return;
        UpdateQualityBeforeSellInChanges(item);
        item.DecreaseSellInByADay();
        UpdateQualityAfterSellInExpires(item);
    }

    private static void UpdateQualityAfterSellInExpires(Item item)
    {
        if (item.SellIn >= 0) return;
        switch (item.Name)
        {
            case "Aged Brie":
                item.IncreaseQuality();
                return;
            case "Backstage passes to concert":
                item.Quality = 0;
                break;
            case "Fresh apples":
                item.ReduceQuality(2);
                break;
            default:
                item.ReduceQuality();
                return;
        }
    }

    private static void UpdateQualityBeforeSellInChanges(Item item)
    {
        switch (item.Name)
        {
            case "Aged Brie":
                item.IncreaseQuality();
                break;
            case "Backstage passes to concert":
                UpdateBackstagePassesQuality(item);
                break;
            case "Fresh apples":
                item.ReduceQuality(2);
                break;
            default:
                item.ReduceQuality();
                break;
        }
    }

    private static void UpdateBackstagePassesQuality(Item item)
    {
        item.IncreaseQuality();

        if (item.SellIn < 11)
        {
            item.IncreaseQuality();
        }

        if (item.SellIn < 6)
        {
            item.IncreaseQuality();
        }
    }
}
