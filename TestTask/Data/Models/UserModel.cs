using TestTask.Data.ViewModels;

namespace TestTask.Data.Models
{
    public class UserModel
    {
        public Guid ID { get;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public UserModel()
        {
            ID = Guid.NewGuid();
        }
        public UserModel(UserViewModel viewModel)
        {
            ID = Guid.NewGuid();
            FirstName = viewModel.FirstName;
            LastName = viewModel.LastName;
            Age = viewModel.Age;
            Email = viewModel.Email;
        }
        public void Update(UserViewModel viewModel)
        {
            FirstName = viewModel.FirstName;
            LastName = viewModel.LastName;
            Age = viewModel.Age;
            Email = viewModel.Email;
        }
    }
}
