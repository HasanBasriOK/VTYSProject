using MiniHbys.Entity;

namespace MiniHbys.DataAccess.Abstraction;

public interface IUserManager
{
    void CreateUser(User user);
    User Login(string username, string password);
    bool IsUserExist(string email);
    void UpdateUser(User user);
}