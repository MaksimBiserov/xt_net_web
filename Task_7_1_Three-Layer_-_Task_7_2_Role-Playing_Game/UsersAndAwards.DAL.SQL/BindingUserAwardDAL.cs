using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using UsersAndAwards.DAL.Interfaces;
using UsersAndAwards.Entities;

namespace UsersAndAwards.DAL.SQL
{
    public class BindingUserAwardDAL : IBindingUserAwardDAL
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;
        SqlCommand command;

        public void Add(Guid userID, Guid awardID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.AddBindingUserAward";

                SqlParameter userIDParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.Guid,
                    ParameterName = "@UserID",
                    Value = userID,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(userIDParameter);

                SqlParameter awardIDParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.Guid,
                    ParameterName = "@AwardID",
                    Value = awardID,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(awardIDParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteUser(Guid userID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "DELETE FROM [BindingUserAward] WHERE [UserID] = @param1";
                command.Parameters.AddWithValue("@param1", userID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteAward(Guid awardID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "DELETE FROM [BindingUserAward] WHERE [AwardID] = @param1";
                command.Parameters.AddWithValue("@param1", awardID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteByID(Guid userID, Guid awardID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "DELETE FROM [BindingUserAward] WHERE [AwardID] = @param1 AND [UserID] = @param2";
                command.Parameters.AddWithValue("@param1", awardID);
                command.Parameters.AddWithValue("@param2", userID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<BindingUserAward> GetAll(Guid userID)
        {
            List<BindingUserAward> users = new List<BindingUserAward>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT [AwardID] FROM [BindingUserAward] WHERE [UserID] = @param1";
                command.Parameters.AddWithValue("@param1", userID);
                connection.Open();
                SqlDataReader executeReader = command.ExecuteReader();

                while (executeReader.Read())
                {
                    users.Add(new BindingUserAward()
                    {
                        UserID = userID,
                        AwardID = (Guid)executeReader["AwardID"]
                    });
                }
            }

            return users;
        }
    }
}