using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLast.Models
{
    public class Citizen
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [Range(99999999,999999999)]
        public int SSN { get; set; }
        [Display(Name ="First Name")]
        [Required]
        [DataType(DataType.Text)]
        public string First_Name { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        [DataType(DataType.Text)]
        public string Last_Name { get; set; }

        [Display(Name = "Date Of Birth")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Display(Name = "City")]
        //[Required]
       // [DataType(DataType.Text)]
        public int CityCode { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Woreda { get; set; }
        
        [Required]
        [Range(0,99)]
        public int Kebele { get; set; }

        [Display(Name = "Blood Type")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(10)]
        public string Blood_Type { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        
        [Required]
        [Range(0,999)]
        public int Age { get; set; }
        [NotMapped]
        public virtual ICollection<SelectListItem> Citiy { get; set; }
        [ForeignKey("SSN")]
        public ICollection<Permission> Permission { get; set; }
    }
}
