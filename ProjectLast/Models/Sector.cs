using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLast.Models
{
    public class Sector
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Sector Name Can't Be Empty")]
        [DataType(DataType.Text,ErrorMessage = "Name Is String Type")]
        [Display(Name ="Sector Name")]
        public string Name { get; set; }
        [Required( ErrorMessage = "Photo Can't Be Empty")]
        [DataType(DataType.Text)]
        [FileExtensions(Extensions ="jpg,png,jpeg")]
        public string Photo { get; set; }
        [Display(Name = "Sector Service")]
        [Required (ErrorMessage = "Detail Can't Be Empty")]
        [DataType(DataType.MultilineText)]
        public string Detail { get; set; }
       
        [Required(ErrorMessage = "Email Can't Be Empty")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Sector Information Type")]
        public string Info_Type { get; set; }
    }
}
