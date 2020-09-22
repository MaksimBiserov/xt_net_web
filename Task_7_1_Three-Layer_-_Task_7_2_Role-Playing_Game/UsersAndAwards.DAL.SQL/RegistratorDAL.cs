using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using UsersAndAwards.DAL.Interfaces;
using UsersAndAwards.Entities;

namespace UsersAndAwards.DAL.SQL
{
    public class RegistratorDAL : IRegistratorDAL
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;
        SqlCommand command;

        public void AddRoleGuest(Registrator regUser)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.AddRegistrator";

                SqlParameter iDParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.Guid,
                    ParameterName = "@ID",
                    Value = regUser.ID,
                    Direction = System.Data.ParameterDirection.Output
                };

                command.Parameters.Add(iDParameter);

                SqlParameter loginParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@Login",
                    Value = regUser.Login,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(loginParameter);

                SqlParameter passwordParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@Password",
                    Value = regUser.Password,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(passwordParameter);

                SqlParameter roleParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@Role",
                    Value = regUser.Role[0],
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(roleParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void AddRoleUser(Guid iD)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                IEnumerable<Registrator> user = GetAll().Where(item => item.ID == iD);
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "UPDATE [Registrator] SET [Role]='User' WHERE [ID]=@param1";
                command.Parameters.AddWithValue("@param1", iD);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void AddRoleAdmin(Guid iD)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                IEnumerable<Registrator> user = GetAll().Where(item => item.ID == iD);

                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "UPDATE [Registrator] SET [Role]='Admin' WHERE [ID]=@param1";
                command.Parameters.AddWithValue("@param1", iD);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Registrator> GetAll()
        {
            var users = new List<Registrator>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT [ID], [Login], [Password], [Role] FROM [Registrator]";
                connection.Open();
                SqlDataReader executeReader = command.ExecuteReader();

                while (executeReader.Read())
                {
                    Guid id = (Guid)executeReader["ID"];
                    string login = executeReader["Login"].ToString();
                    string password = executeReader["Password"].ToString();
                    string role = executeReader["Role"].ToString();
                    users.Add(new Registrator { ID = id, Login = login, Password = password, Role = new [] { role } });
                }
            }

            return users;
        }
    }
}