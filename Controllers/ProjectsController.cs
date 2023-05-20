using DonationApplication.Data;
using DonationApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DonationApplication.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: Projects
        public ActionResult Index()
        {//views all projects
            List<ProjectModel> projects = new List<ProjectModel>();
            ProjectDAO _projectDAO = new ProjectDAO();
            projects = _projectDAO.GetAllProjects();
            return View("Index", projects);   
        }
        public ActionResult ViewProjectsByOrganizationCode(string orgCode)
        {//views all projects by Organization Code
            List<ProjectModel> projects = new List<ProjectModel>();
            ProjectDAO _projectDAO = new ProjectDAO();
            projects = _projectDAO.GetProjectsByOrganizationCode(orgCode);
            return View("Index", projects);
        }

        public ActionResult ViewProjectListByCountryCode(List<ProjectModel> projects)
        {
            return View("ViewProjectListByCountryCode", projects);
        }

        public ActionResult CreateNewProject(string organizationCode, string organizationName, string countryName)
        {
            ViewBag.countryName = countryName;
            ViewBag.organizationName = organizationName;
            ProjectModel project = new ProjectModel
            {
                PROJECT_ORGANIZATION_CODE = organizationCode
            };

            return View("CreateNewProject", project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProjectInDB(ProjectModel project, List<HttpPostedFileBase> images)
        {
            string imageLocations = "";
            if (images != null && images.Count > 0)
            {
                foreach (var image in images)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    var imagePath = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    image.SaveAs(imagePath);
                    imageLocations += imagePath.ToString() + ",";
                }

            }
            if (imageLocations != "")
            {
                imageLocations = imageLocations.Remove(imageLocations.Length - 1, 1);
            }

            ProjectDAO _dao = new ProjectDAO();
            int success = _dao.insertOrUpdateProjects(project, imageLocations);
            return RedirectToAction("Index");
        }

        //getting projects by countryCode
        public ActionResult GetProjectsByCountryCode(string country_code)
        {
            List<ProjectModel> projects = new List<ProjectModel>();
            ProjectDAO _projectDAO = new ProjectDAO();
            projects = _projectDAO.GetProjectsByCountry(country_code);


            return View("ViewProjectListByCountryCode", projects);
        }

        public ActionResult GetProjectDetails(int id)
        {
            ProjectModel project = new ProjectModel();
            ProjectDAO _projectDAO = new ProjectDAO();
            project = _projectDAO.GetProjectsDetails(id);


            return View("GetProjectDetails", project);
        }
    }
}