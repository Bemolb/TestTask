using Microsoft.AspNetCore.Mvc;
using TestTask.Data;
using TestTask.Data.Models;
using TestTask.Data.ViewModels;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserStorageController : ControllerBase
    {
        private readonly ILogger<UserStorageController> _logger;
        private UserStorage _storage;

        public UserStorageController(ILogger<UserStorageController> logger)
        {
            _logger = logger;
            _storage = new UserStorage();
        }

        [HttpGet(Name = "GetAllUsers")]
        public Dictionary<Guid, UserViewModel> Get()
        {                        
            return _storage.Users.ToDictionary(user => user.ID, user => new UserViewModel(user));
        }
        [HttpPost(Name = "AddUser")]
        public Dictionary<Guid, UserViewModel> Add(UserViewModel user)
        {
            UserModel userModel = new UserModel(user);
            _storage.AddUser(userModel);
            return _storage.Users.ToDictionary(user => user.ID, user => new UserViewModel(user));
        }
        [HttpDelete(Name = "DeleteUser")]
        public Dictionary<Guid, UserViewModel> Delete(Guid id)
        {
            _storage.DeleteUser(id);
            return _storage.Users.ToDictionary(user => user.ID, user => new UserViewModel(user));
        }
        [HttpPut(Name = "EditUser")]
        public Dictionary<Guid, UserViewModel> Edit(Guid id, UserViewModel user)
        {
            _storage.UpdateUser(id, user);
            return _storage.Users.ToDictionary(user => user.ID, user => new UserViewModel(user));
        }
    }
}