using Microsoft.AspNetCore.Mvc;

namespace MiniHbys.Web.Controllers;

public class InspectionController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}