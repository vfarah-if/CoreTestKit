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
        UpdateQualityBeforeSellInChanges(item);

        if (item.Name != "Diamond ring")
        {
            item.SellIn -= 1;
        }

        UpdateQualityAfterSellInChange(item);
    }

    private static void UpdateQualityAfterSellInChange(Item item)
    {
        if (item.SellIn >= 0) return;
        if (item.Name == "Aged Brie")
        {
            IncreaseQuality(item);
            return;
        }
        if (item.Name != "Backstage passes to concert")
        {
            if (item.Name != "Diamond ring")
            {
                ReduceQuality(item);
            }
        }
        else
        {
            ReduceQuality(item, item.Quality);
        }
    }

    private static void UpdateQualityBeforeSellInChanges(Item item)
    {
        if (item.Name != "Aged Brie" && item.Name != "Backstage passes to concert")
        {
            if (item.Name != "Diamond ring")
            {
                ReduceQuality(item);
            }
        }
        else
        {
            IncreaseQuality(item);

            if (item.Name == "Backstage passes to concert")
            {
                if (item.SellIn < 11)
                {
                    IncreaseQuality(item);
                }

                if (item.SellIn < 6)
                {
                    IncreaseQuality(item);
                }
            }
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
