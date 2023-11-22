using ItemRazorV1Real.Comperators;
using ItemRazorV1Real.MockData;
using ItemRazorV1Real.Models;

namespace ItemRazorV1Real.Service
{
    public class ItemService : IItemService
    {
        private List<Item> _items;
        private JsonFileItemService JsonFileItemService { get; set; }

        public ItemService(JsonFileItemService jsonFileItemService)
        {
            JsonFileItemService = jsonFileItemService;
            //_items = MockItems.GetMockItems();
            _items = JsonFileItemService.GetJsonItems().ToList();

        }

        public List<Item> GetItems()
        {
            return _items;
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
            JsonFileItemService.SaveJsonItems(_items);
        }

        public IEnumerable<Item> NameSearch(string str)
        {
            List<Item> nameSearch = new List<Item>();
            foreach (Item item in _items)
            {
                if (item.Name.ToLower().Contains(str.ToLower()))
                {
                    nameSearch.Add(item);
                }
            }

            return nameSearch;
        }

        //public IEnumerable<Item> PriceFilter(int maxPrice, int minPrice = 0)
        //{
        //    List<Item> filterList = new List<Item>();
        //    foreach (Item item in _items)
        //    {
        //        if ((minPrice == 0 && item.Price <= maxPrice) || (maxPrice == 0 && item.Price >= minPrice) || (item.Price >= minPrice && item.Price <= maxPrice))
        //        {
        //            filterList.Add(item);
        //        }
        //    }

        //    return filterList;
        //}

        public IEnumerable<Item> PriceFilter(int maxPrice, int minPrice =0)
        {
            return from item in _items
                   where (minPrice == 0 && item.Price == maxPrice) ||
                   (maxPrice == 0 && item.Price >= minPrice) ||
                   (item.Price >= minPrice && item.Price <= maxPrice)
                   select item;
        }



        public void UpdateItem(Item item)
        {
            if (item != null)
            {
                foreach (Item i in _items)
                {
                    if (i.Id == item.Id)
                    {
                        i.Name = item.Name;
                        i.Price = item.Price;
                    }
                }
                JsonFileItemService.SaveJsonItems(_items);
            }
        }

        public Item GetItem(int id)
        {
            if (id != null)
            {
                foreach (Item item in _items)
                {
                    if (item.Id == id)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        public Item DeleteItem(int? itemId)
        {
            Item itemToBeDeleted = null;
            foreach (Item item in _items)
            {
                if (item.Id == itemId)
                {
                    itemToBeDeleted = item;
                    break;
                }
            }
            if (itemToBeDeleted != null)
            {
                _items.Remove(itemToBeDeleted);
                JsonFileItemService.SaveJsonItems(_items);
            }
            return itemToBeDeleted;
        }

        //public IEnumerable<Item> SortById()
        //{
        //    _items.Sort();
        //    return _items;
        //}

        public IEnumerable<Item> SortById()
        {
            return from item in _items
                   orderby item.Id
                   select item;
        }

        //public IEnumerable<Item> SortByIdDescending()
        //{
        //    _items.Sort();
        //    _items.Reverse();
        //    return _items;
        //}

        public IEnumerable<Item> SortByIdDescending()
        {
            return from item in _items
                   orderby item.Id descending
                   select item;
        }

        //public IEnumerable<Item> SortByName()
        //{
        //    _items.Sort(new NameComperator());
        //    return _items;
        //}

        public IEnumerable<Item> SortByName()
        {
            return from item in _items
                   orderby item.Name
                   select item;
        }

        //public IEnumerable<Item> SortByNameDescending()
        //{
        //    _items.Sort(new NameComperator());
        //    _items.Reverse();
        //    return _items;
        //}

        public IEnumerable<Item> SortByNameDescending()
        {
            return from item in _items
                   orderby item.Name descending
                   select item;
        }

        //public IEnumerable<Item> SortByPrice()
        //{
        //    _items.Sort(new PriceComperator());
        //    return _items;
        //}

        public IEnumerable<Item> SortByPrice()
        {
            return from item in _items
                   orderby item.Price
                   select item;
        }

        //public IEnumerable<Item> SortByPriceDescending()
        //{
        //    _items.Sort(new PriceComperator());
        //    _items.Reverse();
        //    return _items;
        //}

        public IEnumerable <Item> SortByPriceDescending()
        {
            return from item in _items
                   orderby item.Name descending
                   select item;
        }
    }
}
