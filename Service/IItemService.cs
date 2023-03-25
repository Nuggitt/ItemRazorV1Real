using ItemRazorV1Real.Models;

namespace ItemRazorV1Real.Service
{
    public interface IItemService
    {
        List<Item> GetItems();

        void AddItem(Item item);
    }
}
