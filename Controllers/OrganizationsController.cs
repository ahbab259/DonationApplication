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
            CountryDAO countryDAO = new CountryDAO();

            ViewBag.CountrySelectList = new SelectList(countryDAO.GetAllCountry(), "COUNTRY_CODE", "COUNTRY_NAME");
            return View("NewOrganizationCreate");
        }

        public ActionResult ProcessCreate(OrganizationsModel org)
        {
            CountryDAO countryDAO = new CountryDAO();
            List<CountryModel> countries = new List<CountryModel>();
            countries = countryDAO.GetAllCountry();

            OrganizationDAO orgDao = new OrganizationDAO();
            string selectedCountryName = countries.Where(c => c.COUNTRY_CODE == org.OrganizationCountryCode).FirstOrDefault().COUNTRY_NAME;
            org.OrganizationCountryName = selectedCountryName;
            int success = orgDao.insertOrUpdateOrganization(org);

            return View("Details", org);
        }

        public ActionResult Edit(int id)
        {
            CountryDAO countryDAO = new CountryDAO();
            ViewBag.CountrySelectList = new SelectList(countryDAO.GetAllCountry(), "COUNTRY_CODE", "COUNTRY_NAME");

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

        public ActionResult ShowAllCountries()
        {
            List<CountryModel> countries = new List<CountryModel>();
            CountryDAO countryDAO = new CountryDAO();
            countries = countryDAO.GetAllCountry();

            return View("CountryList", countries);
        }

        public ActionResult GetImage(int id)
        {
            CountryModel country = new CountryModel();
            CountryDAO countryDAO = new CountryDAO();
            country = countryDAO.GetCountryImage(id);

            var image = country.COUNTRY_IMAGE;
            if (image != null)
            {
                return File(image, "image/jpeg");
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult CountryDetails(string country_code)
        {
            List<OrganizationsModel> organizations = new List<OrganizationsModel>();
            OrganizationDAO organizationsDAO = new OrganizationDAO();
            organizations = organizationsDAO.GetOrganizationByCountryCode(country_code);

            return View("Index", organizations);
        }
    }
}