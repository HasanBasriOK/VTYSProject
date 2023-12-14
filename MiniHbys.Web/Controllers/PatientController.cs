using Microsoft.AspNetCore.Mvc;

namespace MiniHbys.Web.Controllers;

public class PatientController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}