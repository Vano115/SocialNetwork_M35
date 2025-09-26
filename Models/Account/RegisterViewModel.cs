using System.ComponentModel.DataAnnotations;

namespace SocialNetwork_M35.Models.Account
{
    public class RegisterViewModel
    {
        // Без добавления модификотора required вылетает предупреждение
        [Required]
        [Display(Name = "Имя")]
        required public string FirstName { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        required public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        required public string EmailReg { get; set; }

        [Required]
        [Display(Name = "Год")]
        public int Year { get; set; }

        [Required]
        [Display(Name = "День")]
        public int Date { get; set; }

        [Required]
        [Display(Name = "Месяц")]
        public int Month { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [StringLength(100, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.", MinimumLength = 5)]
        required public string PasswordReg { get; set; }

        [Required]
        [Compare("PasswordReg", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        required public string PasswordConfirm { get; set; }

        [Required]
        [Display(Name = "Логин")]
        required public string Login { get; set; }
    }
}
