using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLast.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Sector Name")]
        [Required(ErrorMessage = "Sector Name is Required")]
        [DataType(DataType.Text,ErrorMessage ="Sector Name is Type of Alphabet")]

        public string Sector_Name { get; set; }
        [Display(Name = "Associated Document")]
        [Required(ErrorMessage = "Associated Document is Required")]
        [FileExtensions(Extensions ="jpg,png,jpeg")]
        public string Associated_Doc { get; set; }
        [Display(Name = "Branch Name")]
        [Required(ErrorMessage = "Branch Name is Required")]
        [DataType(DataType.Text, ErrorMessage = "Branch Name is Type of Alphabet")]
        public string Branch_Name { get; set; }
        [Display(Name = "Request Status")]
        [DefaultValue("Not_Approved")]
        [Required]
        [DataType(DataType.Text)]
        public string Req_Status { get; set; }
        [Display(Name = "Account Status")]
        [DefaultValue("Not_Active")]
        [Required]
        [DataType(DataType.Text)]
        public string Acc_Status { get; set; }
    }
}
