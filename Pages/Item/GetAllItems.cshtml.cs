using ItemRazorV1Real.MockData;
using ItemRazorV1Real.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItemRazorV1Real.Pages.Item
{
    public class GetAllItemsModel : PageModel
    {
        private IItemService _itemService;

        public GetAllItemsModel(IItemService itemService)
        {
            _itemService = itemService;
            
        }

        public List<Models.Item> Items { get; private set; } = new List<Models.Item>()
        {
            
        };

        public void OnGet()
        {
            Items = _itemService.GetItems();
        }
    }
}
