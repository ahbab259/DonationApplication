using DonationApplication.Data;
using DonationApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DonationApplication.Controllers
{
    public class DonationController : Controller
    {
        CountryDAO _countryDataFromDB = new CountryDAO();
        OrganizationDAO _orgDataFromDB = new OrganizationDAO();
        ProjectDAO _projFromDB = new ProjectDAO();
        // GET: Donation
        public ActionResult Index()
        {
            List<CountryModel> CountryList = _countryDataFromDB.GetAllCountry().ToList();
            ViewBag.CountryList = new SelectList(CountryList, "COUNTRY_CODE", "COUNTRY_NAME");
            return View();
        }

        public JsonResult GetOrgByCountryCode(string countryCode)
        {
            List<OrganizationsModel> orgList = new List<OrganizationsModel>();
            orgList = _orgDataFromDB.GetOrganizationByCountryCode(countryCode);
            return Json(orgList, JsonRequestBehavior.AllowGet);
        }
    }
}