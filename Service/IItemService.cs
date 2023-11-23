using ItemRazorV1Real.Models;

namespace ItemRazorV1Real.Service
{
    public interface IItemService
    {
        List<Item> GetItems();

        void AddItem(Item item);

        IEnumerable<Item> NameSearch(string str);

        IEnumerable<Item> NameSearchLambda(string str);

        IEnumerable<Item> PriceFilter(int maxPrice, int minPrice = 0);

        IEnumerable<Item> PriceFilterLambda(int maxPrice, int minPrice = 0);

        void UpdateItem(Item item);

        Item GetItem(int id);

        Item DeleteItem(int? itemId);

        IEnumerable<Item> SortById();

        IEnumerable<Item> SortByIdDescending();

        IEnumerable<Item> SortByName();

        IEnumerable<Item> SortByNameDescending();

        IEnumerable<Item> SortByPrice();

        IEnumerable<Item> SortByPriceDescending();

    }
}
