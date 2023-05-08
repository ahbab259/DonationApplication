using DonationApplication.Data;
using DonationApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DonationApplication.Controllers
{
    public class OrganizationsController : Controller
    {
        // GET: Organizations
        public ActionResult Index()
        {
            List<OrganizationsModel> organizations = new List<OrganizationsModel>();
            OrganizationDAO organizationsDAO = new OrganizationDAO();
            organizations = organizationsDAO.FetchAll();
            return View("Index", organizations);
        }

        // GET: Organization by Id
        public ActionResult Details(int id)
        {
            OrganizationsModel organization = new OrganizationsModel();
            OrganizationDAO organizationsDAO = new OrganizationDAO();
            organization = organizationsDAO.GetOrganizationDetails(id);
            return View("Details", organization);
        }

        public ActionResult NewOrganizationCreate()
        {
            return View("NewOrganizationCreate");
        }

        public ActionResult ProcessCreate(OrganizationsModel org)
        {
            OrganizationDAO orgDao = new OrganizationDAO();
            int success = orgDao.insertOrUpdateOrganization(org);

            return View("Details", org);
        }

        public ActionResult Edit(int id)
        {
            OrganizationsModel organization = new OrganizationsModel();
            OrganizationDAO organizationsDAO = new OrganizationDAO();
            organization = organizationsDAO.GetOrganizationDetails(id);
            return View("NewOrganizationCreate", organization);
        }

        public ActionResult Delete(int id)
        {
            OrganizationsModel organization = new OrganizationsModel();
            OrganizationDAO organizationsDAO = new OrganizationDAO();
            organization = organizationsDAO.GetOrganizationDetails(id);
            return View("DetailsBeforeDelete", organization);
        }

        public ActionResult DeleteFromDB(int id)
        {
            List<OrganizationsModel> organizations = new List<OrganizationsModel>();
            OrganizationDAO organizationsDAO = new OrganizationDAO();
            int success = organizationsDAO.DeleteOrganization(id);

            organizations = organizationsDAO.FetchAll();
            return View("Index", organizations);
        }
    }
}