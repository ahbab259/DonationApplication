using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DonationApplication.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("PROJECT NAME *")]
        public string PROJECT_NAME { get; set; }
        [Required]
        [DisplayName("PROJECT DESCRIPTION *")]
        public string PROJECT_DESCRIPTION { get; set; }
        [Required]
        [DisplayName("PROJECT CODE *")]
        public string PROJECT_CODE { get; set; }
        [Required]
        [DisplayName("PROJECT ORGANIZATION CODE *")]
        public string PROJECT_ORGANIZATION_CODE { get; set; }
        [Required]
        [DisplayName("PROJECT FUND")]
        public int PROJECT_FUND { get; set; }
        [Required]
        [DisplayName("PROJECT TARGET FUND")]
        public int PROJECT_TARGET_FUND { get; set; }
    }
}