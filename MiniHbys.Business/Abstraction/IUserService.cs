using MiniHbys.Entity;

namespace MiniHbys.Business.Abstraction;

public interface IUserService
{
    void CreateUser(User user);
}