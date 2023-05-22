using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DonationApplication.Models
{
    public class UserModel
    {   
        public int Id { get; set; }
        [Required]
        [DisplayName("FIRST_NAME *")]
        public string FIRST_NAME { get; set; }
        [Required]
        [DisplayName("MIDDLE_NAME *")]
        public string MIDDLE_NAME { get; set; }
        [Required]
        [DisplayName("LAST_NAME *")]
        public string LAST_NAME { get; set; }
        [Required]
        [DisplayName("EMAIL *")]
        public string EMAIL { get; set; }
        [Required]
        [DisplayName("USER_NAME")]
        public string USER_NAME { get; set; }
        [Required]
        [DisplayName("PASSWORD")]
        public string PASSWORD { get; set; }
        [Required]
        [DisplayName("USER_TYPE *")]
        public string USER_TYPE { get; set; }
        [Required]
        [DisplayName("ADDRESS_LINE_1 *")]
        public string ADDRESS_LINE_1 { get; set; }
        [Required]
        [DisplayName("ADDRESS_LINE_2 ")]
        public string ADDRESS_LINE_2 { get; set; }
        [Required]
        [DisplayName("POSTAL_CODE *")]
        public string POSTAL_CODE { get; set; }
        [Required]
        [DisplayName("CITY")]
        public string CITY { get; set; }
        [Required]
        [DisplayName("STATE")]
        public string STATE { get; set; }
        [Required]
        [DisplayName("USER_COUNTRY")]
        public string USER_COUNTRY { get; set; }
        [Required]
        [DisplayName("USER_CELL_PHONE")]
        public string USER_CELL_PHONE { get; set; }

    }
}