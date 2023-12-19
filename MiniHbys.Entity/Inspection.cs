namespace MiniHbys.Entity;

public class Inspection
{
    public int InspectionID { get; set; }
    public DateTime? InspectionDate { get; set; }
    public int DoctorID { get; set; }
    public int PatientID { get; set; }
    public string InspectionResult { get; set; }
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
}