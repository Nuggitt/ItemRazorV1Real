using ItemRazorV1Real.Models;

namespace ItemRazorV1Real.MockData
{
    public class MockUsers
    {
        private static List<User> Users = new List<User>()
        {
            new User("Leder1", "123"),
            new User("Leder2", "123"),
            new User("Leder3", "123")
        };

        public static List<User> GetMockUsers()
        {
            return Users;
        }
    }
}
