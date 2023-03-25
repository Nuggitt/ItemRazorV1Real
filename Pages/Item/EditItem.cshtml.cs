using ItemRazorV1Real.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItemRazorV1Real.Pages.Item
{
    public class EditItemModel : PageModel
    {
        private IItemService _itemService;

        [BindProperty] public Models.Item Item { get; set; }

        public EditItemModel(IItemService itemService)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _itemService.UpdateItem(Item);
            return RedirectToPage("GetAllItems");
        }
    }
}
