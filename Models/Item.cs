using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItemRazorV1Real.Models
{
    public class Item : IComparable<Item>
    {
        [Display(Name = "Item ID")]
        [Required(ErrorMessage = "Der skal angives et ID til Item")]
        [Range(typeof(int), "0", "10000", ErrorMessage = "ID skal være mellem {1} og {2}")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }

        
        [Display(Name = "Item Navn")]
        [Required(ErrorMessage = "Item skal have et navn")]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Pris")]
        [Required(ErrorMessage = "Der skal angives en pris")]
        public decimal Price { get; set; }

        public Item(int id, string name, decimal price)
        {
            Id= id;
            Name= name;
            Price= price;
        }

        public Item()
        {
            Id = 0;
            Name = "";
            Price = 0;
        }

        public int CompareTo(Item other)
        {
            if(Id > other.Id)
            {
                return +1;
            }
            if(Id == other.Id)
            {
                return 0;
            }
            if(Id < other.Id)
            {
                return -1;
            }
            return 0;
        }








    }
}
