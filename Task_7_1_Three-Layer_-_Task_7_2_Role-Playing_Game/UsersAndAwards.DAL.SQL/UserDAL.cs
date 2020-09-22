using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using UsersAndAwards.DAL.Interfaces;
using UsersAndAwards.Entities;

namespace UsersAndAwards.DAL.SQL
{
    public class UserDAL : IUserDAL
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;
        SqlCommand command;

        public Guid Add(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.AddUser";

                SqlParameter iDParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.Guid,
                    ParameterName = "@ID",
                    Value = user.ID,
                    Direction = System.Data.ParameterDirection.Output
                };

                command.Parameters.Add(iDParameter);

                SqlParameter nameParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@UserName",
                    Value = user.Name,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(nameParameter);

                SqlParameter ageParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@Age",
                    Value = DateTime.Now.Year - user.DateOfBirth.Year,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(ageParameter);

                SqlParameter dateOfBirthParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.DateTime,
                    ParameterName = "@DateOfBirth",
                    Value = user.DateOfBirth,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(dateOfBirthParameter);
                connection.Open();
                command.ExecuteNonQuery();
                return (Guid)iDParameter.Value;
            }
        }

        public void DeleteById(Guid iD)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "DELETE FROM [User] WHERE [ID] = @param1";
                command.Parameters.AddWithValue("@param1", iD);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT [ID], [UserName], [Age], [DateOfBirth] FROM [User]";
                connection.Open();
                SqlDataReader executeReader = command.ExecuteReader();

                while (executeReader.Read())
                {
                    users.Add(new User()
                    {
                        ID = (Guid)executeReader["ID"],
                        Name = executeReader["UserName"] as string,
                        Age = (int)executeReader["Age"],
                        DateOfBirth = (DateTime)executeReader["DateOfBirth"]
                    });
                }
            }

            return users;
        }

        public void EditUser(Guid userID, string name, DateTime dateOfBirth)
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "UPDATE [User] SET [UserName] = @param2, [Age] = @param3, [DateOfBirth] = @param4 WHERE [ID] = @param1";
                command.Parameters.AddWithValue("@param1", userID);
                command.Parameters.AddWithValue("@param2", name);
                command.Parameters.AddWithValue("@param3", age);
                command.Parameters.AddWithValue("@param4", dateOfBirth);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}