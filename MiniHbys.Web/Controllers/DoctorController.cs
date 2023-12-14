using Microsoft.AspNetCore.Mvc;

namespace MiniHbys.Web.Controllers;

public class DoctorController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}