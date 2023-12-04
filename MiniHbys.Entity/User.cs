namespace MiniHbys.Entity;

public class User
{
    public int UserID { get; set; }
    public string UserEmail { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public string UserSurname { get; set; }
    public DateTime? BirthDate { get; set; }
    public int RoleId { get; set; }
}