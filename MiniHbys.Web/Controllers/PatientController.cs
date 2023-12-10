using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using MiniHbys.Business.Abstraction;
using MiniHbys.Business.Services;
using MiniHbys.Entity;
using MiniHbys.Web.Models;

namespace MiniHbys.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreatePatient()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePatient(Patient patient)
        {
            _patientService.CreatePatient(patient);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> ListPatient()
        {
            var patients = _patientService.GetAllPatients();
            return View(patients);
        }
        public IActionResult UpdatePatient(Patient patient)
        {
            _patientService.UpdatePatient(patient);
            return RedirectToAction("ListPatient");
        }
        public IActionResult DetailPatient(int id)
        {
            var p = _patientService.DetailPatientByID(id);
            return View("UpdatePatient", p);
        }
        public IActionResult DeletePatient(int id)
        {
            _patientService.DeletePatient(id);
            return RedirectToAction("ListPatient");
        }
    }
}
