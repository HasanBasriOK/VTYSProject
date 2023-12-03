using MiniHbys.Business.Abstraction;
using MiniHbys.DataAccess.Abstraction;
using MiniHbys.DataAccess.Managers;
using MiniHbys.Entity;
using MiniHbys.Utilities;

namespace MiniHbys.Business.Services;

public class UserService : IUserService
{
    private readonly IUserManager _userManager;
    public UserService(IUserManager userManager)
    {
        _userManager = userManager;
    }

    public void CreateUser(User user)
    {
        var encryptedPassword = EncyptionHelper.Encrypt(user.Password, AppConstants.EncryptionKey);
        user.Password = encryptedPassword;
        
       _userManager.CreateUser(user);
    }
}