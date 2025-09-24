using System.ComponentModel.DataAnnotations;

namespace SocialNetwork_M35.Models
{
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        required public string Password { get; set; }

        [Required]
        [Display(Name = "Логин")]
        required public string Login { get; set; }

        [Required]
        [Display(Name = "Запомнить меня")]
        required public bool RememberMe { get; set; }

        [Required]
        [Display(Name = "ReturnUrl")]
        required public string ReturnUrl { get; set; }

    }
}
