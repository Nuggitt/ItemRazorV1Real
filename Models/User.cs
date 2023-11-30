using System.ComponentModel.DataAnnotations;

namespace ItemRazorV1Real.Models
{
    public class User
    {
        [Key]
        [StringLength(20)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public User()
        {
            UserName = "";
            Password = "";
        }
    }
}
