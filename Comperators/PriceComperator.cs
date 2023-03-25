using ItemRazorV1Real.Models;

namespace ItemRazorV1Real.Comperators
{
    public class PriceComperator : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            return x.Price.CompareTo(y.Price);
        }
    }
}
