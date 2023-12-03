using Microsoft.AspNetCore.Mvc;
using MiniHbys.Business.Abstraction;
using MiniHbys.Business.Services;
using MiniHbys.Entity;

namespace MiniHbys.Web.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateUser(User user)
    {
        _userService.CreateUser(user);
        return Ok();
    }
}