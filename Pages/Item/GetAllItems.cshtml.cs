using ItemRazorV1Real.MockData;
using ItemRazorV1Real.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItemRazorV1Real.Pages.Item
{
    public class GetAllItemsModel : PageModel
    {
        private IItemService _itemService;
        [BindProperty] public string SearchString { get; set; }

        [BindProperty] public int MinPrice { get; set; }
        [BindProperty] public int MaxPrice { get; set; }

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

        public IActionResult OnPostNameSearch()
        {
            Items = _itemService.NameSearch(SearchString).ToList();
            return Page();
        }

        public IActionResult OnPostPriceFilter()
        {
            Items = _itemService.PriceFilter(MaxPrice,MinPrice).ToList();
            return Page();
        }

        public IActionResult OnGetSortById()
        {
            Items = _itemService.SortById().ToList();
            return Page();
        }

        public IActionResult OnGetSortByIdDescending()
        {
            Items = _itemService.SortByIdDescending().ToList();
            return Page();
        }

        public IActionResult OnGetSortByName()
        {
            Items = _itemService.SortByName().ToList();
            return Page();
        }

        public IActionResult OnGetSortByNameDescending()
        {
            Items = _itemService.SortByNameDescending().ToList();
            return Page();
        }

        public IActionResult OnGetSortByPrice()
        {
            Items = _itemService.SortByPrice().ToList();
            return Page();
        }

        public IActionResult OnGetSortByPriceDescending()
        {
            Items = _itemService.SortByPriceDescending().ToList();
            return Page();
        }
    }
}
