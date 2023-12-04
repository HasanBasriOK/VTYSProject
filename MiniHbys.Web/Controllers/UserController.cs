using Microsoft.AspNetCore.Mvc;
using MiniHbys.Business.Abstraction;
using MiniHbys.Business.Services;
using MiniHbys.Entity;
using MiniHbys.Web.Models;

namespace MiniHbys.Web.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        //Login Actions
        return RedirectToAction(actionName: "Index", controllerName: "Home");
    }
    
    [HttpPost]
    public IActionResult CreateUser(User user)
    {
        _userService.CreateUser(user);
        return Ok();
    }

    public IActionResult Register()
    {
        
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterViewModel model)
    {
        //register actions
        return RedirectToAction(actionName: "Login", controllerName: "User");
    }
}