using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using SocialNetwork_M35.Data.Entityes;
using SocialNetwork_M35.Models.Account;

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

                var result = await _userManager.CreateAsync(user, model.PasswordReg);
                var erors = result.Errors;
                foreach (var eror in erors)
                {
                    _logger.LogInformation(eror.Description);
                }

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    // RedirectToAction - перенаправляет пользователя по указаному пути
                    return RedirectToAction("Index", "Home");
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
    }
}
