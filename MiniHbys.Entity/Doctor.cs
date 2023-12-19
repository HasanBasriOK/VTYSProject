namespace MiniHbys.Entity;

public class Doctor
{
    public int DoctorID { get; set; }
    public string DoctorName { get; set; }
    public string DoctorSurname { get; set; }
    public int DepartmentID { get; set; }
    public Department Department { get; set; }
}