using DonationApplication.Data;
using DonationApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DonationApplication.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: Projects
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateNewProject(string orgCode)
        {
            ProjectModel project = new ProjectModel
            {
                PROJECT_ORGANIZATION_CODE = orgCode
            };

            return View("CreateNewProject", project);
        }

        public ActionResult CreateProjectInDB(ProjectModel project)
        {
            ProjectDAO _dao = new ProjectDAO();
            //int success = _dao.insertOrUpdateProjects(project);
            return View("CreateNewProject");
        }
    }
}