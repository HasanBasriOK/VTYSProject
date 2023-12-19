using Microsoft.AspNetCore.Mvc;
using MiniHbys.Business.Abstraction;

namespace MiniHbys.Web.Controllers;

public class MedicalOperationController : Controller
{
    private readonly IMedicalOperationService _medicalOperationService;

    public MedicalOperationController(IMedicalOperationService medicalOperationService)
    {
        _medicalOperationService = medicalOperationService;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }
}