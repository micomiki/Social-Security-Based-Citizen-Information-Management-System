using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLast.Models
{
    public class SSN
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "City Code")]
        [Required]
         
        public int CityCode { get; set; }

        [Display(Name = "Current Code")]
        [Required]
        public int CurrentNumber { get; set; }
        // code should be forign key from city
    }
}
