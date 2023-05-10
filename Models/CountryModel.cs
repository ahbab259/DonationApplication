using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace DonationApplication.Models
{
    public class CountryModel
    {
        public int Id { get; set; }
        public string COUNTRY_NAME { get; set; }
        public string COUNTRY_CODE { get; set; }
        public string COUNTRY_CODE_ALPHA_3 { get; set; }
    }
}