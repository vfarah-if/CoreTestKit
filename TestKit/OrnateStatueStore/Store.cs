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
                    if (item.Quality > 0)
                    {
                        if (item.Name != "Diamond ring")
                        {
                            item.Quality -= 1;
                        }
                    }
                }
                else
                {
                    item.Quality -= item.Quality;
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;
                }
            }
        }
    }

    private static void UpdateQualityBeforeSellInChanges(Item item)
    {
        if (item.Name != "Aged Brie" && item.Name != "Backstage passes to concert")
        {
            if (item.Quality > 0)
            {
                if (item.Name != "Diamond ring")
                {
                    item.Quality -= 1;
                }
            }
        }
        else
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;

                if (item.Name == "Backstage passes to concert")
                {
                    if (item.SellIn < 11)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;
                        }
                    }

                    if (item.SellIn < 6)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;
                        }
                    }
                }
            }
        }
    }
}
