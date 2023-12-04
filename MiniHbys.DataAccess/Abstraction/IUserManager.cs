using MiniHbys.Entity;

namespace MiniHbys.DataAccess.Abstraction;

public interface IUserManager
{
    void CreateUser(User user);
    User Login(string username, string password);
}