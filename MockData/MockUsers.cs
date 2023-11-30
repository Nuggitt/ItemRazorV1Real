using ItemRazorV1Real.Models;
using Microsoft.AspNetCore.Identity;

namespace ItemRazorV1Real.MockData
{
    public class MockUsers
    {
        private static PasswordHasher<string> passwordHasher = new PasswordHasher<string>();

        private static List<User> Users = new List<User>()
        {
            new User("Leder1",passwordHasher.HashPassword(null, "123")),
            new User("Leder2",passwordHasher.HashPassword(null, "123")),
            new User("Leder3",passwordHasher.HashPassword(null, "123")),
            new User("admin", passwordHasher.HashPassword(null, "secret")),
            new User("admin1", passwordHasher.HashPassword(null, "secret"))


        };

        public static List<User> GetMockUsers()
        {
            return Users;
        }
    }
}
