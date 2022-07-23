using DeviceStore.Portal.App.ViewModels;

using DeviceStore.Services.Users.Contract;
using DeviceStore.Services.Users.Contract.Models;
using DeviceStore.Services.Users.Contract.Models.Commands;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace DeviceStore.Portal.App.Controllers;

public class AccountController : Controller
{
    private readonly IUsersService _usersService;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccountController(
        //UserManager<User> userManager,
        //SignInManager<User> signInManager,
        IUsersService userService)
    {
        _usersService = userService;
        //_userManager = userManager;
        //_signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(
        RegisterViewModel model,
        CancellationToken cancellationToken = default)
    {
        var command = new CreateUserCommand(
            model.Login,
            model.Password,
            model.FirstName,
            model.LastName,
            model.Phone,
            model.Email);

        if (ModelState.IsValid)
        {
            var result = await _usersService
            .Create(command, cancellationToken)
            //.WithActionResult()
            .ConfigureAwait(false);

            if (result is not null)
            {
                return RedirectToAction("Index", "Home");
            }

            //// добавляем пользователя
            //var result = await _userManager.CreateAsync(user, model.Password);
            //if (result.Succeeded)
            //{
            //    // установка куки
            //    await _signInManager.SignInAsync(user, false);
            //    
            //}
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult Login(string returnUrl = null)
    {
        return View(new LoginViewModel { ReturnUrl = returnUrl });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(
        LoginViewModel model,
        CancellationToken cancellationToken = default)
    {
        var isValid = ModelState.IsValid;

        var command = new GetUserByLoginPasswordCommand(model.Login, model.Password);
        var result = _usersService.GetUserByLoginPassword(command, cancellationToken).Result;

        if (result is not null)
        {
            //var result =
            //    await _signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, false);
            //if (result.Succeeded)
            //{
                // проверяем, принадлежит ли URL приложению
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
            //}
        }
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        // удаляем аутентификационные куки
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}