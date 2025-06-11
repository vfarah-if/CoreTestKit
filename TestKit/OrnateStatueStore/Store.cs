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
        DecreaseSellInByADay(item);
        UpdateQualityAfterSellInExpires(item);
    }

    private static void UpdateQualityAfterSellInExpires(Item item)
    {
        if (item.SellIn >= 0) return;
        switch (item.Name)
        {
            case "Aged Brie":
                IncreaseQuality(item);
                return;
            case "Backstage passes to concert":
                item.Quality = 0;
                break;
            default:
                ReduceQuality(item);
                return;
        }
    }

    private static void UpdateQualityBeforeSellInChanges(Item item)
    {
        switch (item.Name)
        {
            case "Aged Brie":
                IncreaseQuality(item);
                break;
            case "Backstage passes to concert":
                UpdateBackstagePassesQuality(item);
                break;
            default:
                ReduceQuality(item);
                break;
        }
    }

    private static void UpdateBackstagePassesQuality(Item item)
    {
        IncreaseQuality(item);

        if (item.SellIn < 11)
        {
            IncreaseQuality(item);
        }

        if (item.SellIn < 6)
        {
            IncreaseQuality(item);
        }
    }

    private static void ReduceQuality(Item item, int amount = 1)
    {
        if (item.Quality > 0)
        {
            item.Quality -= amount;
        }
    }

    private static void IncreaseQuality(Item item, int amount = 1)
    {
        if (item.Quality < 50)
        {
            item.Quality += amount;
        }
    }

    private static void DecreaseSellInByADay(Item item)
    {
        item.SellIn -= 1;
    }
}
