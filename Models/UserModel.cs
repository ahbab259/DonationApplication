using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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


        //[Required]
        //[DisplayName("PASSWORD")]
        //[DataType(DataType.Password)]
        //[StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{6,}$", ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")]
        [Required(ErrorMessage = "*Required Field")]
        [DataType(DataType.Password)]
        [MaxLength(15, ErrorMessage = "Password cannot be longer than 15 characters.")]
        public string PASSWORD { get; set; }



        [NotMapped] // Does not effect with your database
        [Required(ErrorMessage = "Please enter confirm password")]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }




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