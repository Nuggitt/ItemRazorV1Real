using ItemRazorV1Real.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItemRazorV1Real.Pages.Item
{
    public class DeleteItemModel : PageModel
    {
        private IItemService _itemService;

        [BindProperty]
        public Models.Item Item { get; set; }

        public DeleteItemModel(IItemService itemService)
        {
            _itemService = itemService;
        }

        public IActionResult OnGet(int id)
        {
            Item = _itemService.GetItem(id);
            if (Item == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return Page();
        }

        public IActionResult OnPost()
        {
            Models.Item deletedItem = _itemService.DeleteItem(Item.Id);
            if (deletedItem == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu
            return RedirectToPage("GetAllItems");
        }
    }
}
