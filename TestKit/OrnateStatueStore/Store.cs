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
        UpdateQualityAfterSellInChanges(item);
    }

    private static void DecreaseSellInByADay(Item item)
    {
        item.SellIn -= 1;
    }

    private static void UpdateQualityAfterSellInChanges(Item item)
    {
        if (item.SellIn >= 0) return;
        if (item.Name == "Aged Brie")
        {
            IncreaseQuality(item);
            return;
        }
        if (item.Name != "Backstage passes to concert")
        {
            ReduceQuality(item);
            return;
        }
        ReduceQuality(item, item.Quality);
    }

    private static void UpdateQualityBeforeSellInChanges(Item item)
    {
        switch (item.Name)
        {
            case "Aged Brie":
                IncreaseQuality(item);
                break;
            case "Backstage passes to concert":
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

                    break;
                }
            default:
                ReduceQuality(item);
                break;
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
}
