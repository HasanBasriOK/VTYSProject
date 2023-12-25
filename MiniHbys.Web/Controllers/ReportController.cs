using Microsoft.AspNetCore.Mvc;

namespace MiniHbys.Web.Controllers;

public class ReportController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}