using ItemRazorV1Real.Models;

namespace ItemRazorV1Real.Comperators
{
    public class NameComperator : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            return x.Name.CompareTo(y.Name);
        }

    }
}
