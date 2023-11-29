using ItemRazorV1Real.MockData;
using ItemRazorV1Real.Models;

namespace ItemRazorV1Real.Service
{
    public class UserService
    {
        public List<User> Users { get; set; }
        private JsonFileService<User> _jsonFileService;

        public UserService(JsonFileService<User> jsonFileService)
        {
            _jsonFileService = jsonFileService;
            //Users = MockUsers.GetMockUsers();
            Users = _jsonFileService.GetJsonObjects().ToList();
            _jsonFileService.SaveJsonObjects(Users);
        }
    }
}
