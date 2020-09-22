using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using UsersAndAwards.DAL.Interfaces;
using UsersAndAwards.Entities;

namespace UsersAndAwards.DAL.SQL
{
    public class AwardDAL : IAwardDAL
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;
        SqlCommand command;

        public Guid Add(Award award)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.AddAward";

                SqlParameter iDParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.Guid,
                    ParameterName = "@ID",
                    Value = award.ID,
                    Direction = System.Data.ParameterDirection.Output
                };

                command.Parameters.Add(iDParameter);

                SqlParameter titleParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@Title",
                    Value = award.Title,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(titleParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }

            return award.ID;
        }

        public void DeleteById(Guid iD)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "DELETE FROM [Award] WHERE [ID] = @param1";
                command.Parameters.AddWithValue("@param1", iD);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Award> GetAll()
        {
            List<Award> awards = new List<Award>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT [ID], [Title] FROM [Award]";
                connection.Open();
                SqlDataReader executeReader = command.ExecuteReader();

                while (executeReader.Read())
                {
                    awards.Add(new Award()
                    {
                        ID = (Guid)executeReader["ID"],
                        Title = executeReader["Title"] as string
                    });
                }
            }
            return awards;
        }

        public void EditAward(Guid awardID, string title)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "UPDATE [Award] SET [Title] = @param2 WHERE [ID] = @param1";
                command.Parameters.AddWithValue("@param1", awardID);
                command.Parameters.AddWithValue("@param2", title);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}