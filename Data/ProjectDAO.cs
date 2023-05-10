using DonationApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DonationApplication.Data
{
    internal class ProjectDAO
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DonationApplication;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int insertOrUpdateProjects(ProjectModel project)
        {
            int success = 1;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("dbo.INSERT_OR_UPDATE_PROJECT", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", project.Id);
                    cmd.Parameters.AddWithValue("@PROJECT_NAME", project.PROJECT_NAME);
                    cmd.Parameters.AddWithValue("@PROJECT_DESCRIPTION", project.PROJECT_DESCRIPTION);
                    cmd.Parameters.AddWithValue("@PROJECT_CODE", project.PROJECT_CODE);
                    cmd.Parameters.AddWithValue("@PROJECT_ORGANIZATION_CODE", project.PROJECT_ORGANIZATION_CODE);
                    cmd.Parameters.AddWithValue("@PROJECT_FUND", project.PROJECT_FUND);
                    cmd.Parameters.AddWithValue("@PROJECT_TARGET_FUND", project.PROJECT_TARGET_FUND);

                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

                return success;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                success = 0;
                return success;
            }
        }
    }
}