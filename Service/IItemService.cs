using ItemRazorV1Real.Models;

namespace ItemRazorV1Real.Service
{
    public interface IItemService
    {
        List<Item> GetItems();

        void AddItem(Item item);

        IEnumerable<Item> NameSearch(string str);

        IEnumerable<Item> PriceFilter(int maxPrice, int minPrice = 0);

        void UpdateItem(Item item);

        Item GetItem(int id);

        public Item DeleteItem(int? itemId);
    }
}
