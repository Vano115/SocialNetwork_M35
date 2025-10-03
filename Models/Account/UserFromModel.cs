using SocialNetwork_M35.Data.Entityes;

namespace SocialNetwork_M35.Models.Account
{
    public static class UserFromModel
    {
        public static User Convert(this User user, UserEditViewModel usereditvm)
        {
            user.MainImage = usereditvm.MainImage;
            user.LastName = usereditvm.LastName;
            user.MiddleName = usereditvm.MiddleName;
            user.FirstName = usereditvm.FirstName;
            user.Email = usereditvm.Email;
            user.BirthDate = usereditvm.BirthDate;
            user.UserName = usereditvm.UserName;
            user.Status = usereditvm.Status;
            user.About = usereditvm.About;

            return user;
        }
    }
}
