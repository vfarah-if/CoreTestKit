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

    private static void UpdateQualityBeforeSellInChanges(Item item)
    {
        switch (item.Name)
        {
            case "Aged Brie":
                UpdateAgedBrie(item);
                break;
            case "Backstage passes to concert":
                UpdateBackstagePassesQuality(item);
                break;
            case "Fresh apples":
                UpdateFreshApples(item);
                break;
            default:
                UpdateDefault(item);
                break;
        }
    }

    private static void UpdateQualityAfterSellInExpires(Item item)
    {
        if (item.SellIn >= 0) return;
        switch (item.Name)
        {
            case "Aged Brie":
                UpdatedAgedBrieWhenExpired(item);
                return;
            case "Backstage passes to concert":
                UpdateExpiredConcert(item);
                break;
            case "Fresh apples":
                UpdateExpiredFreshApples(item);
                break;
            default:
                UpdateDefaultExpiredItem(item);
                return;
        }
    }

    private static void UpdateDefaultExpiredItem(Item item)
    {
        item.ReduceQuality();
    }

    private static void UpdateExpiredFreshApples(Item item)
    {
        item.ReduceQuality(2);
    }

    private static void UpdateExpiredConcert(Item item)
    {
        item.Quality = 0;
    }

    private static void UpdatedAgedBrieWhenExpired(Item item)
    {
        item.IncreaseQuality();
    }

    private static void UpdateDefault(Item item)
    {
        item.ReduceQuality();
    }

    private static void UpdateFreshApples(Item item)
    {
        item.ReduceQuality(2);
    }

    private static void UpdateAgedBrie(Item item)
    {
        item.IncreaseQuality();
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
