using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Mvc;
using MiniHbys.Business.Abstraction;
using MiniHbys.DataAccess.Managers;
using MiniHbys.Entity;
using MiniHbys.Web.Models;

namespace MiniHbys.Web.Controllers;

public class ReportController : Controller
{
    private readonly IReportService _reportService;
    private readonly IPatientService _patientService;
    private readonly IDoctorService _doctorService;

    public ReportController(IReportService reportService, IPatientService patientService, IDoctorService doctorService)
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
        var reportJson = System.Text.Json.JsonSerializer.Serialize(inspections);
        HttpContext.Session.SetString("InspectionsByDateReport", reportJson);
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
        var reportJson = System.Text.Json.JsonSerializer.Serialize(inspections);
        HttpContext.Session.SetString("InspectionsByDoctorReport", reportJson);
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
        var reportJson = System.Text.Json.JsonSerializer.Serialize(inspections);
        HttpContext.Session.SetString("InspectionsByPatientReport", reportJson);
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
        var reportJson = System.Text.Json.JsonSerializer.Serialize(medicineItems);
        HttpContext.Session.SetString("MedicineItemsByPatientReport", reportJson);
        return View(medicineItems);
    }

    public IActionResult GetPatientsByBirthDate()
    {
        return View();
    }

    [HttpPost]
    public IActionResult GetPatientsByBirthDateReport(GetPatientsByBirthDateViewModel model)
    {
        if (model.EndDate <= model.StartDate)
        {
            ViewBag.Message = "End date have to be greater than start date";
            return View(viewName: "GetPatientsByBirthDate");
        }

        var patients = _reportService.GetPatientsByBirthDate(model.StartDate, model.EndDate);
        var reportJson = System.Text.Json.JsonSerializer.Serialize(patients);
        HttpContext.Session.SetString("PatientsByBirthDateReport", reportJson);
        return View(patients);
    }

    public IActionResult ExportReport(string reportName)
    {
        var reportJson = HttpContext.Session.GetString(reportName);
        string fileName = string.Empty;
        switch (reportName)
        {
            case "PatientsByBirthDateReport":
                var patientsByBirtDate = System.Text.Json.JsonSerializer.Deserialize<List<Patient>>(reportJson);
                fileName =
                    $"PatientsByBirthDateReport_{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}-{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}-{DateTime.Now.Millisecond}";
                Utilities.ExportData.ExportCsv(patientsByBirtDate, fileName);
                break;
            case "MedicineItemsByPatientReport":
                var medicineItemByPatients = System.Text.Json.JsonSerializer.Deserialize<List<Patient>>(reportJson);
                fileName =
                    $"MedicineItemsByPatientReport_{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}-{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}-{DateTime.Now.Millisecond}";
                Utilities.ExportData.ExportCsv(medicineItemByPatients, fileName);
                break;
            case "InspectionsByPatientReport":
                var inspectionsByPatient = System.Text.Json.JsonSerializer.Deserialize<List<Patient>>(reportJson);
                fileName =
                    $"InspectionsByPatientReport_{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}-{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}-{DateTime.Now.Millisecond}";
                Utilities.ExportData.ExportCsv(inspectionsByPatient, fileName);
                break;
            case "InspectionsByDoctorReport":
                var inspectionsByDoctor = System.Text.Json.JsonSerializer.Deserialize<List<Patient>>(reportJson);
                fileName =
                    $"InspectionsByDoctorReport_{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}-{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}-{DateTime.Now.Millisecond}";
                Utilities.ExportData.ExportCsv(inspectionsByDoctor, fileName);
                break;
            case "InspectionsByDateReport":
                var inspectionsByDate = System.Text.Json.JsonSerializer.Deserialize<List<Patient>>(reportJson);
                fileName =
                    $"InspectionsByDateReport_{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}-{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}-{DateTime.Now.Millisecond}";
                Utilities.ExportData.ExportCsv(inspectionsByDate, fileName);
                break;
        }

        return RedirectToAction("Index");
    }
}