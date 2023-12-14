using Microsoft.AspNetCore.Mvc;

namespace MiniHbys.Web.Controllers;

public class MedicalOperationController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}