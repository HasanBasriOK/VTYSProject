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
        using(var connection = new SqlConnection(GlobalSettings.ConnectionString))
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

    public User Login(string username, string password)
    {
        User user = null;
        using (var connection = new SqlConnection(GlobalSettings.ConnectionString))
        {
            connection.Open();
            var commandString = @"SELECT * FROM User WHERE Email = @Username AND Password = @Password";
            using (var command = new SqlCommand(commandString,connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    user = new User();
                    user.UserID = reader["UserID"].ToInt32();
                    user.UserSurname = reader["UserSurname"] != DBNull.Value
                        ? reader["UserSurname"].ToString()
                        : string.Empty;
                    user.UserName = reader["UserName"] != DBNull.Value ? reader["UserName"].ToString() : string.Empty;
                    user.UserEmail = reader["UserEmail"] != DBNull.Value
                        ? reader["UserEmail"].ToString()
                        : string.Empty;
                    user.RoleId = reader["RoleId"] != DBNull.Value ? reader["RoleId"].ToInt32() : default;
                    user.BirthDate = reader["Birthdate"] != DBNull.Value ? reader["Birthdate"].ToDateTime() : null;
                    user.Password = reader["Password"] != DBNull.Value ? reader["Password"].ToString() : string.Empty;
                }
            }
        }
        return user;
    }
}