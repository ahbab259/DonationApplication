﻿using DonationApplication.Models;
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

        public List<ProjectModel> GetAllProjects()
        {
            List<ProjectModel> projectList = new List<ProjectModel>();
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("dbo.GET_ALL_PROJECTS", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    dt.Load(cmd.ExecuteReader());
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            foreach (DataRow dr in dt.Rows)
            {
                ProjectModel _project = new ProjectModel();
                _project.Id = Convert.ToInt32(dr["Id"]);
                _project.PROJECT_NAME = dr["PROJECT_NAME"].ToString();
                _project.PROJECT_DESCRIPTION = dr["PROJECT_DESCRIPTION"].ToString();
                _project.PROJECT_CODE = dr["PROJECT_CODE"].ToString();
                _project.PROJECT_ORGANIZATION_CODE = dr["PROJECT_ORGANIZATION_CODE"].ToString();
                _project.PROJECT_FUND = Convert.ToDecimal(dr["PROJECT_FUND"].ToString());
                _project.PROJECT_TARGET_FUND = Convert.ToDecimal(dr["PROJECT_TARGET_FUND"].ToString());

                projectList.Add(_project);
            }
            return projectList;
        }
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

        public List<ProjectModel> GetProjectsByCountry(string countryCode)
        {
            List<ProjectModel> projectList = new List<ProjectModel>();
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("dbo.GET_PROJECTS_BY_COUNTRY_CODE", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrganizationCountryCode", countryCode);

                    dt.Load(cmd.ExecuteReader());
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            foreach (DataRow dr in dt.Rows)
            {
                ProjectModel _project = new ProjectModel();
                _project.Id = Convert.ToInt32(dr["Id"]);
                _project.PROJECT_NAME = dr["PROJECT_NAME"].ToString();
                _project.PROJECT_DESCRIPTION = dr["PROJECT_DESCRIPTION"].ToString();
                _project.PROJECT_CODE = dr["PROJECT_CODE"].ToString();
                _project.PROJECT_ORGANIZATION_CODE = dr["PROJECT_ORGANIZATION_CODE"].ToString();
                _project.PROJECT_FUND = Convert.ToDecimal(dr["PROJECT_FUND"].ToString());
                _project.PROJECT_TARGET_FUND = Convert.ToDecimal(dr["PROJECT_TARGET_FUND"].ToString());

                projectList.Add(_project);
            }
            return projectList;
        }
        public List<ProjectModel> GetProjectsByOrganizationCode(string orgCode)
        {
            List<ProjectModel> projectList = new List<ProjectModel>();
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("dbo.GET_PROJECTS_BY_ORGANIZATION_CODE", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrganizationCountryCode", orgCode);

                    dt.Load(cmd.ExecuteReader());
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            foreach (DataRow dr in dt.Rows)
            {
                ProjectModel _project = new ProjectModel();
                _project.Id = Convert.ToInt32(dr["Id"]);
                _project.PROJECT_NAME = dr["PROJECT_NAME"].ToString();
                _project.PROJECT_DESCRIPTION = dr["PROJECT_DESCRIPTION"].ToString();
                _project.PROJECT_CODE = dr["PROJECT_CODE"].ToString();
                _project.PROJECT_ORGANIZATION_CODE = dr["PROJECT_ORGANIZATION_CODE"].ToString();
                _project.PROJECT_FUND = Convert.ToDecimal(dr["PROJECT_FUND"].ToString());
                _project.PROJECT_TARGET_FUND = Convert.ToDecimal(dr["PROJECT_TARGET_FUND"].ToString());

                projectList.Add(_project);
            }
            return projectList;
        }
    }
}