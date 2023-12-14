namespace MiniHbys.Entity;

public class MedicineItem
{
    public int MedicineItemID { get; set; }
    public string MedicineName { get; set; }
    public int InspectionID { get; set; }
    public int PatientID { get; set; }
}