using Microsoft.Data.SqlClient;
using MiniHbys.DataAccess.Abstraction;
using MiniHbys.Entity;
using MiniHbys.Utilities;

namespace MiniHbys.DataAccess.Managers;

public class UserManager : IUserManager
{
    public void CreateUser(User user)
    {
        //ADO.NET
        using (var connection = new SqlConnection(GlobalSettings.ConnectionString))
        {
            connection.Open();
            var commandText = @"INSERT INTO User (UserEmail,Password,UserName,UserSurname,BirthDate,RoleId) VALUES
        (@UserEmail,@Password,@UserName,@UserSurname,@BirthDate,@RoleId)";
            using (var command = new SqlCommand(commandText, connection))
            {
                command.Parameters.AddWithValue("@UserEmail", user.UserEmail);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@UserSurname", user.UserSurname);
                command.Parameters.AddWithValue("@BirthDate", user.BirthDate);
                command.Parameters.AddWithValue("@RoleId", user.RoleId);

                command.ExecuteNonQuery();
            }
        }
    }
}