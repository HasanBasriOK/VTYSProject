using Microsoft.AspNetCore.Mvc;
using MiniHbys.Business.Abstraction;
using MiniHbys.Web.Models;

namespace MiniHbys.Web.Controllers;

public class ReportController : Controller
{
    private readonly IReportService _reportService;
    private readonly IPatientService _patientService;
    private readonly IDoctorService _doctorService;

    public ReportController(IReportService reportService,IPatientService patientService,IDoctorService doctorService)
    {
        _reportService = reportService;
        _patientService = patientService;
        _doctorService = doctorService;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetInspectionsByDate()
    {
        return View();
    }

    [HttpPost]
    public IActionResult GetInspectionsByDateReport(GetInspectionByDateViewModel model)
    {
        if (model.EndDate <= model.StartDate)
        {
            ViewBag.Message = "End date have to be greater than start date";
            return View(viewName: "GetInspectionsByDate");
        }
        
        var inspections = _reportService.GetInspectionsByDate(model.StartDate, model.EndDate);
        return View(inspections);
    }
    
    public IActionResult GetInspectionsByDoctor()
    {
        var doctors = _doctorService.GetAllDoctors();
        ViewBag.Doctors = doctors;
        return View();
    }

    [HttpPost]
    public IActionResult GetInspectionsByDoctorReport(GetInspectionByDoctorViewModel model)
    {
        if (model.DoctorID == 0)
        {
            ViewBag.Message = "Please choose doctor";
            return View(viewName: "GetInspectionsByDoctor");
        }
        
        var inspections = _reportService.GetInspectionsByDoctor(model.DoctorID);
        return View(inspections);
    }
    
    public IActionResult GetInspectionsByPatient()
    {
        var patients = _patientService.GetAllPatients();
        ViewBag.Patients = patients;
        return View();
    }

    [HttpPost]
    public IActionResult GetInspectionsByPatientReport(GetInspectionByPatientViewModel model)
    {
        if (model.PatientID == 0)
        {
            ViewBag.Message = "Please choose patient";
            return View(viewName: "GetInspectionsByPatient");
        }
        
        var inspections = _reportService.GetInspectionsByPatient(model.PatientID);
        return View(inspections);
    }
    
    public IActionResult GetMedicineItemsByPatient()
    {
        var patients = _patientService.GetAllPatients();
        ViewBag.Patients = patients;
        return View();
    }

    [HttpPost]
    public IActionResult GetMedicineItemsByPatientReport(GetMedicineItemsByPatientViewModel model)
    {
        if (model.PatientID == 0)
        {
            ViewBag.Message = "Please choose patient";
            return View(viewName: "GetMedicineItemsByPatient");
        }
        
        var medicineItems = _reportService.GetMedicineItemsByPatient(model.PatientID);
        return View(medicineItems);
    }
    
    public IActionResult GetPatientsByBirthDate()
    {
        return View();
    }

    [HttpPost]
    public IActionResult GetPatientsByBirthDateReport(GetPatientsByBirthDateViewModel model)
    {
        if (model.EndDate<= model.StartDate)
        {
            ViewBag.Message = "End date have to be greater than start date";
            return View(viewName: "GetPatientsByBirthDate");
        }
        
        var patients = _reportService.GetPatientsByBirthDate(model.StartDate,model.EndDate);
        return View(patients);
    }
}