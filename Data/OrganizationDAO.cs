using DonationApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DonationApplication.Data
{
    internal class OrganizationDAO
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DonationApplication;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //returns all organizations
        public List<OrganizationsModel> FetchAll()
        {
            DataTable dt = new DataTable();
            List<OrganizationsModel> returnList = new List<OrganizationsModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("dbo.GET_ALL_ORGANIZATIONS", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                dt.Load(cmd.ExecuteReader());
                connection.Close();
            }

            foreach (DataRow dr in dt.Rows)
            {
                OrganizationsModel organization = new OrganizationsModel();
                organization.Id = Convert.ToInt32(dr["Id"]);
                organization.OrganizationName = dr["OrganizationName"].ToString();
                organization.OrganizationDescription = dr["OrganizationDescription"].ToString();
                organization.OrganizationCountryCode = dr["OrganizationCountryCode"].ToString();
                organization.OrganizationEmail = dr["OrganizationEmail"].ToString();
                organization.OrganizationPhone = dr["OrganizationPhone"].ToString();
                returnList.Add(organization);
            }

            return returnList;
        }

        //returns one organization by ID
        public OrganizationsModel GetOrganizationDetails(int id)
        {
            DataTable dt = new DataTable();
            OrganizationsModel organization = new OrganizationsModel();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("dbo.GET_ORGANIZATION_BY_ID", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                dt.Load(cmd.ExecuteReader());
                connection.Close();
            }

            foreach (DataRow dr in dt.Rows)
            {
                organization.Id = Convert.ToInt32(dr["Id"]);
                organization.OrganizationName = dr["OrganizationName"].ToString();
                organization.OrganizationDescription = dr["OrganizationDescription"].ToString();
                organization.OrganizationCountryCode = dr["OrganizationCountryCode"].ToString();
                organization.OrganizationEmail = dr["OrganizationEmail"].ToString();
                organization.OrganizationPhone = dr["OrganizationPhone"].ToString();
            }

            return organization;
        }

        //inserts a new organization
        public int insertOrUpdateOrganization(OrganizationsModel org)
        {
            int success = 1;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("dbo.INSERT_OR_UPDATE_ORGANIZATION", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", org.Id);
                    cmd.Parameters.AddWithValue("@OrganizationName", org.OrganizationName);
                    cmd.Parameters.AddWithValue("@OrganizationType", org.OrganizationType);
                    cmd.Parameters.AddWithValue("@OrganizationDescription", org.OrganizationDescription);
                    cmd.Parameters.AddWithValue("@OrganizationCountryCode", org.OrganizationCountryCode);
                    cmd.Parameters.AddWithValue("@OrganizationEmail", org.OrganizationEmail);
                    cmd.Parameters.AddWithValue("@OrganizationPhone", org.OrganizationPhone);

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

        public int DeleteOrganization(int id)
        {
            int success = 1;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("dbo.DELETE_ORGANIZATION", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

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