using SocialNetwork_M35.Data.Entityes;

namespace SocialNetwork_M35.Models.Account
{
    // Представление данных пользователя
    public class UserViewModel
    {
        public User User { get; set; }

        public string FullName { get; set; }

        public UserViewModel(User user)
        {
            User = user;

            FullName = user.GetFullName();

        }
    }
}
