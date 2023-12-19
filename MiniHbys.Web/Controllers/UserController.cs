using Microsoft.AspNetCore.Mvc;
using MiniHbys.Business.Abstraction;
using MiniHbys.Common.WebViewModels;
using MiniHbys.Entity;


namespace MiniHbys.Web.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly IRoleService _roleService;
    public UserController(IUserService userService,IRoleService roleService)
    {
        _userService = userService;
        _roleService = roleService;
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
    
    public IActionResult Index()
    {
        var users = _userService.GetAllUsers();
        return View(users);
    }
    
    public IActionResult Detail(int id)
    {
        var user = _userService.GetUserById(id);
        return View(user);
    }

    public IActionResult Edit(int id)
    {
        var roles = _roleService.GetAllRoles();
        var user = _userService.GetUserById(id);
        ViewBag.Roles = roles;
        return View(user);
    }

    [HttpPost]
    public IActionResult Edit(User user)
    {
        _userService.UpdateUser(user);
        return RedirectToAction(actionName: "Index", controllerName: "User");
    }

    public IActionResult Create()
    { 
        var roles = _roleService.GetAllRoles();
        ViewBag.Roles = roles;
        return View();
    }

    [HttpPost]
    public IActionResult Create(User user)
    {
        _userService.CreateUser(user);
        return RedirectToAction(actionName: "Index", controllerName: "User");
    }

    public IActionResult Delete(int id)
    {
        _userService.DeleteUser(id);
        return RedirectToAction(actionName: "Index", controllerName: "User");
    }
}