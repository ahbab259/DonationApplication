using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DonationApplication.Models
{
    public class DonationModel
    {
        public int Id { get; set; }
        public string USER_NAME { get; set; }
        public string COUNTRY_CODE { get; set; }
        public string COUNTRY_NAME { get; set; }
        public string ORGANIZATION_NAME { get; set; }
        public string PROJECT_NAME { get; set; }
        public decimal DONATION_AMOUNT { get; set; }
    }
}