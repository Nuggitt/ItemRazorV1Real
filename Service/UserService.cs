using ItemRazorV1Real.MockData;
using ItemRazorV1Real.Models;

namespace ItemRazorV1Real.Service
{
    public class UserService
    {
        public List<User> Users { get; }
        private JsonFileService<User> _jsonFileService;
        //private DbService _dbService;
        private DbGenericService<User> _dbService;


        public UserService(JsonFileService<User> jsonFileService, DbGenericService<User> dbService)
        {
            _jsonFileService = jsonFileService;
            _dbService = dbService;
            //Users = MockUsers.GetMockUsers();
            //Users = _jsonFileService.GetJsonObjects().ToList();
            //_jsonFileService.SaveJsonObjects(Users);
            //Users = _dbService.GetUsers().Result;
            //_dbService.SaveUsers(Users);
            Users = _dbService.GetObjectsAsync().Result.ToList();


        }

        public void AddUser(User user)
        {
            Users.Add(user);
            _jsonFileService.SaveJsonObjects(Users);
            //_dbService.SaveUsers(Users);
        }

    }
}
