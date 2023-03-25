using ItemRazorV1Real.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItemRazorV1Real.Pages.Item
{
    public class CreateItemModel : PageModel
    {
        private IItemService _itemService;
        [BindProperty]
        public Models.Item Item { get; set; }

        public CreateItemModel(IItemService itemService)
        {
            _itemService = itemService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            _itemService.AddItem(Item);
            return RedirectToPage("GetAllItems");
        }
    }
}
