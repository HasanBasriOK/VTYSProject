using Microsoft.Data.SqlClient;
using MiniHbys.DataAccess.Abstraction;
using MiniHbys.Entity;
using MiniHbys.Utilities;

namespace MiniHbys.DataAccess.Managers;

public class RoleManager : IRoleManager
{
    public void CreateRole(Role role)
    {
        using (var connection = new SqlConnection(GlobalSettings.ConnectionString))
        {
            connection.Open();
            var commandText = @"INSERT INTO Role (RoleName,RoleDescription,IsSuperAdmin) VALUES (@RoleName,
            @RoleDescription,@IsSuperAdmin)";
            using (var command = new SqlCommand(commandText,connection))
            {
                command.Parameters.AddWithValue("@RoleName", role.RoleName);
                command.Parameters.AddWithValue("@RoleDescription", role.RoleDescription);
                command.Parameters.AddWithValue("@IsSuperAdmin", role.IsSuperAdmin);
                command.ExecuteNonQuery();
            }
        }
    }

    public void UpdateRole(Role role)
    {
        using (var connection = new SqlConnection(GlobalSettings.ConnectionString))
        {
            connection.Open();
            var commandText = @"UPDATE Role SET RoleName = @RoleName,
                RoleDescription = @RoleDescription,
                IsSuperAdmin = @IsSuperAdmin
                WHERE RoleID = @RoleID";
            using (var command = new SqlCommand(commandText,connection))
            {
                command.Parameters.AddWithValue("@RoleName", role.RoleName);
                command.Parameters.AddWithValue("@RoleDescription", role.RoleDescription);
                command.Parameters.AddWithValue("@IsSuperAdmin", role.IsSuperAdmin);
                command.Parameters.AddWithValue("@RoleID", role.RoleID);
                command.ExecuteNonQuery();
            }
        }
    }

    public Role GetRoleById(int roleId)
    {
        Role role = null;
        using (var connection = new SqlConnection(GlobalSettings.ConnectionString))
        {
            connection.Open();
            var commandText = @"SELECT * FROM Role WHERE RoleID = @RoleID";
            using (var command = new SqlCommand(commandText,connection))
            {
                command.Parameters.AddWithValue("@RoleID", roleId);
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    role = new Role();
                    role.RoleDescription = reader["RoleDescription"] != DBNull.Value
                        ? reader["RoleDescription"]
                            .ToString()
                        : string.Empty;
                    role.RoleName = reader["RoleName"] != DBNull.Value ? reader["RoleName"].ToString() : string.Empty;
                    role.IsSuperAdmin = reader["IsSuperAdmin"] != DBNull.Value
                        ? reader["IsSuperAdmin"].ToBoolean() : false;
                    role.RoleID = reader["RoleID"] != DBNull.Value ? reader["RoleID"].ToInt32() : default;
                }
            }
        }
        return role;
    }

    public List<Role> GetAllRoles()
    {
        var roles = new List<Role>();
        using (var connection = new SqlConnection(GlobalSettings.ConnectionString))
        {
            connection.Open();
            var commandText = @"SELECT * FROM Role";
            using (var command = new SqlCommand(commandText,connection))
            {
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var role = new Role();
                    role.RoleDescription = reader["RoleDescription"] != DBNull.Value
                        ? reader["RoleDescription"]
                            .ToString()
                        : string.Empty;
                    role.RoleName = reader["RoleName"] != DBNull.Value ? reader["RoleName"].ToString() : string.Empty;
                    role.IsSuperAdmin = reader["IsSuperAdmin"] != DBNull.Value
                        ? reader["IsSuperAdmin"].ToBoolean() : false;
                    role.RoleID = reader["RoleID"] != DBNull.Value ? reader["RoleID"].ToInt32() : default;
                    roles.Add(role);
                }
            }
        }

        return roles;
    }

    public void DeleteRole(int roleId)
    {
        using (var connection = new SqlConnection(GlobalSettings.ConnectionString))
        {
            connection.Open();
            var commandText = @"DELETE FROM Role WHERE RoleID = @RoleID";
            using (var command = new SqlCommand(commandText,connection))
            {
                command.Parameters.AddWithValue("@RoleID", roleId);
                command.ExecuteNonQuery();
            }
        }
    }
}