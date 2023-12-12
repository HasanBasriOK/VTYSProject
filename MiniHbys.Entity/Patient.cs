namespace MiniHbys.Entity;

public class Patient
{
    public int PatientID { get; set; }
    public string PatientName { get; set; }
    public string PatientSurname { get; set; }
    public string Gender { get; set; }
    public string BloodGroup { get; set; }
    public DateTime BirthDate { get; set; }
}