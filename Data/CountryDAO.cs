using DonationApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DonationApplication.Data
{
    internal class CountryDAO
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DonationApplication;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<CountryModel> GetAllCountry()
        {
            DataTable dt = new DataTable();
            List<CountryModel> countryList = new List<CountryModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("dbo.GET_ALL_COUNTRY", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                dt.Load(cmd.ExecuteReader());
                connection.Close();
            }

            foreach (DataRow dr in dt.Rows)
            {
                CountryModel country = new CountryModel();
                country.Id = Convert.ToInt32(dr["Id"]);
                country.COUNTRY_CODE = dr["COUNTRY_CODE"].ToString();
                country.COUNTRY_CODE_ALPHA_3 = dr["COUNTRY_CODE_ALPHA_3"].ToString();
                country.COUNTRY_NAME = dr["COUNTRY_NAME"].ToString();

                countryList.Add(country);
            }

            return countryList;
        }

        public CountryModel GetCountryImage(int id)
        {
            DataTable dt = new DataTable();
            CountryModel country = new CountryModel();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("dbo.GET_COUNTRY_IMAGE", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                dt.Load(cmd.ExecuteReader());
                connection.Close();
            }

            foreach (DataRow dr in dt.Rows)
            {
                country.Id = Convert.ToInt32(dr["Id"]);
                country.COUNTRY_CODE = dr["COUNTRY_CODE"].ToString();
                country.COUNTRY_CODE_ALPHA_3 = dr["COUNTRY_CODE_ALPHA_3"].ToString();
                country.COUNTRY_NAME = dr["COUNTRY_NAME"].ToString();

                country.COUNTRY_IMAGE = (byte[])(dr["COUNTRY_IMAGE"]);

            }

            return country;
        }

    }
}