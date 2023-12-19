using Microsoft.AspNetCore.Mvc;
using MiniHbys.Business.Abstraction;
using MiniHbys.Entity;

namespace MiniHbys.Web.Controllers;

public class RoleController : Controller
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }
    // GET
    public IActionResult Index()
    {
        var roles = _roleService.GetAllRoles();
        return View(roles);
    }
    
    public IActionResult Detail(int id)
    {
        var role = _roleService.GetRoleById(id);
        return View(role);
    }

    public IActionResult Edit(int id)
    {
        var role = _roleService.GetRoleById(id);
        return View(role);
    }

    [HttpPost]
    public IActionResult Edit(Role role)
    {
        _roleService.UpdateRole(role);
        return RedirectToAction(actionName: "Index", controllerName: "Role");
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Role role)
    {
        _roleService.CreateRole(role);
        return RedirectToAction(actionName: "Index", controllerName: "Role");
    }

    public IActionResult Delete(int id)
    {
        _roleService.DeleteRole(id);
        return RedirectToAction(actionName: "Index", controllerName: "Role");
    }
}