using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialNetwork_M35.Data.Entityes;
using SocialNetwork_M35.Models.Account;

namespace SocialNetwork_M35.Controllers
{
    [Route("[controller]")]
    public class AccountManagerController : Controller
    {
        private ILogger<AccountManagerController> _logger;
        private IMapper _mapper;

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountManagerController(IMapper mapper, UserManager<User> userManager,
            SignInManager<User> signInManager, ILogger<AccountManagerController> logger)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [Route("Login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                _logger.LogInformation(result.Succeeded.ToString());

                if (result.Succeeded)
                {
                    _logger.LogInformation($"Успешный вход UserName: {model.UserName}, Host: {Request.Host.Host}");
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        // Возврат на страницу из которой перешли в случае успешной авторизации
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        // Переход на главную в случае успешной авторизации
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }

            return View("LoginPage");
        }

        [Route("LoginPage")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginPage(LoginViewModel model)
        {
            _logger.LogInformation(ModelState.IsValid.ToString());

            if (Request.Headers.ContainsKey("Referer"))
            {
                model.ReturnUrl = Request.Headers["Referer"]!.ToString();
            }

            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                _logger.LogInformation(result.Succeeded.ToString());
                if (result.Succeeded)
                {
                    _logger.LogInformation("Успешный вход");
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    _logger.LogInformation("Неудачная попытка входа");
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            // return View(model); - можно использовать в случае одинаковых названий метода контроллера и страницы cshtml
            return View(model);
            //return View("Views/Home/Index.cshtml");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("Выход пользователя");
            return RedirectToAction("Index", "Home");
        }

        [Route("UserProfilePage")]
        [HttpGet]
        [Authorize]

        public IActionResult UserProfilePage()
        {
            var user = User;

            var result = _userManager.GetUserAsync(user);

            return View("Views/User/UserProfilePage.cshtml", new UserViewModel(result.Result));
        }
    }
}
