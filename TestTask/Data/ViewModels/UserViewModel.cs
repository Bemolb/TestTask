using TestTask.Data.Models;

namespace TestTask.Data.ViewModels
{
    public class UserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public UserViewModel() { }
        public UserViewModel(UserModel user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Age = user.Age;
            Email = user.Email;
        }
    }
}
