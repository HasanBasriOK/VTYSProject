using Microsoft.AspNetCore.Mvc;

namespace MiniHbys.Web.Controllers;

public class MedicineItemController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}