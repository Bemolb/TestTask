using TestTask.Data.Models;
using TestTask.Data.ViewModels;

namespace TestTask.Data
{
    public  class UserStorage
    {
        private static List<UserModel> _usersDatabase;

        public List<UserModel> Users { get {  return _usersDatabase; } }

        public UserStorage() 
        {
            if(_usersDatabase == null)
                _usersDatabase = new List<UserModel>();
        }

        public void DeleteUser(Guid guid)
        {
            _usersDatabase.RemoveAll(u => u.ID == guid);
        }

        public void AddUser(UserModel user)
        {
            if (user == null)
                return;
            if (user.ID == Guid.Empty)
                return;
            if (_usersDatabase.Any(u => u.ID == user.ID))
                return;
            _usersDatabase.Add(user);
        }
        public void UpdateUser(Guid id, UserViewModel user)
        {
            if (user == null) 
                return;
            if (id == Guid.Empty)
                return;
            if (_usersDatabase.All(u => u.ID != id))
                return;
            UserModel userModel = _usersDatabase.First(u => u.ID == id);
            userModel.Update(user);
        }
    }
}
