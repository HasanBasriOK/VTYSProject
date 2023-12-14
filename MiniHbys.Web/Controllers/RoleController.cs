using Microsoft.AspNetCore.Mvc;

namespace MiniHbys.Web.Controllers;

public class RoleController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}