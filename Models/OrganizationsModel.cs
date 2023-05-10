using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DonationApplication.Models
{
    public class OrganizationsModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Organization Name *")]
        public string OrganizationName { get; set; }
        [Required]
        [DisplayName("Organization Type *")]
        public string OrganizationType { get; set; }
        [Required]
        [DisplayName("Organization Description *")]
        public string OrganizationDescription { get; set; }

        [Required]
        [DisplayName("Organization Country *")]
        public string OrganizationCountryName { get; set; }
        [Required]
        [DisplayName("Organization Country Code *")]
        public string OrganizationCountryCode { get; set; }
        [Required]
        [DisplayName("Organization Email *")]
        public string OrganizationEmail{ get; set; }
        [Required]
        [DisplayName("Organization Phone *")]
        public string OrganizationPhone{ get; set; }

        [Required]
        [DisplayName("Organization Code *")]
        public string OrganizationCode { get; set; }

        //public OrganizationsModel()
        //{
        //    Id = 0;
        //    OrganizationName = "No Name";
        //    OrganizationType = "No Type";
        //    OrganizationDescription = "No Description";
        //    OrganizationCountryName = "No Country";
        //    OrganizationCountryCode = "00000";
        //    OrganizationEmail = "No Email";
        //    OrganizationPhone = "No Phone";
        //    OrganizationCode = "No Code";
        //}

        //public OrganizationsModel(int id, string organizationName, string organizationType, string organizationDescription, string organizationCountryName, string organizationCountryCode, string organizationEmail, string organizationPhone, string organizationCode)
        //{
        //    Id = id;
        //    OrganizationName = organizationName;
        //    OrganizationType = organizationType;
        //    OrganizationDescription = organizationDescription;
        //    OrganizationCountryName = organizationCountryName;
        //    OrganizationCountryCode = organizationCountryCode;
        //    OrganizationEmail = organizationEmail;
        //    OrganizationPhone = organizationPhone;
        //    OrganizationCode = organizationCode;
        //}
    }
}