using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.VisualBasic;
using SocialNetwork_M35.Data.Entityes;
using SocialNetwork_M35.Models.Account;
using System.Globalization;

namespace SocialNetwork_M35.Controllers
{
    [Route("[controller]")]
    public class RegisterController : Controller
    {
        private ILogger<RegisterController> _logger;
        private IMapper _mapper;

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public RegisterController(IMapper mapper, UserManager<User> userManager, 
            SignInManager<User> signInManager, ILogger<RegisterController> logger)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(model);

                // Маппер не устанавливает дату т.к. обьекты DateTime.Day и т.д. только для чтения
                // Нужно присваивать всё вручную

                user.BirthDate = BirthDate(model.Date, model.Month, model.Year);

                var result = await _userManager.CreateAsync(user, model.PasswordReg);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    // RedirectToAction - перенаправляет пользователя по указаному пути
                    return RedirectToAction("UserProfilePage", "AccountManager");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View("RegisterPart2", model);
        }
        
        [Route("RegisterPart2")]
        [HttpPost]
        public IActionResult RegisterPart2(RegisterViewModel model)
        {
            var user = _mapper.Map<User>(model);
            return View("RegisterPart2", model);
        }

        private DateTime BirthDate(int day, int month, int year)
        {
            DateTime result;
            string dayStr = "0";
            string monthStr = "0";

            if (day < 10)
            {
                dayStr += day;
            }
            else
            {
                dayStr = day.ToString();
            }
            if (month < 10)
            {
                monthStr += month;
            }
            else
            {
                monthStr = month.ToString();
            }

            return result = DateTime.ParseExact($"{dayStr}/{monthStr}/{year}", "dd/MM/yyyy", CultureInfo.CurrentCulture);
        }
    }
}
