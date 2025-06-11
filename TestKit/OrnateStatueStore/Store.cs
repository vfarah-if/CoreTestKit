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
        if (item.SellIn < 0)
        {
            if (item.Name != "Aged Brie")
            {
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
            else
            {
                if (item.Quality < 50)
                {
                    IncreaseQuality(item);
                }
            }
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
            if (item.Quality < 50)
            {
                IncreaseQuality(item);

                if (item.Name == "Backstage passes to concert")
                {
                    if (item.SellIn < 11)
                    {
                        if (item.Quality < 50)
                        {
                            IncreaseQuality(item);
                        }
                    }

                    if (item.SellIn < 6)
                    {
                        if (item.Quality < 50)
                        {
                            IncreaseQuality(item);
                        }
                    }
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
        item.Quality += amount;
    }
}
