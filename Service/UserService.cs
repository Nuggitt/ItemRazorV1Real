using ItemRazorV1Real.MockData;
using ItemRazorV1Real.Models;

namespace ItemRazorV1Real.Service
{
    public class UserService
    {
        public List<User> Users { get; set; }

        public UserService()
        {
            Users = MockUsers.GetMockUsers();
        }
    }
}
