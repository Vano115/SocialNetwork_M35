using SocialNetwork_M35.Data.Entityes;

namespace SocialNetwork_M35.Models.UsersModel
{
    public class UserViewModel
    {
        public User User { get; set; }

        public UserViewModel(User user)
        {
            User = user;
        }
    }
}
