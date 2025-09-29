using System.ComponentModel.DataAnnotations;

namespace SocialNetwork_M35.Models.Account
{
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        required public string Password { get; set; }

        [Required]
        [Display(Name = "Логин")]
        required public string UserName { get; set; }

        [Required]
        [Display(Name = "Запомнить меня")]
        required public bool RememberMe { get; set; }

        
        [Display(Name = "ReturnUrl")]
        public string ?ReturnUrl { get; set; }

    }
}
