using ProjectLast.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLast.Models
{
    public class City:IPrimaryProperties
    {
        [Key]
        //,DatabaseGenerated(DatabaseGeneratedOption.None)
        [Display(Name = "City Code")]
        public int Code { get; set; }

        [Display(Name = "City Name")]
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [ForeignKey("CityCode")]
        public ICollection<SSN> SSN { get; set; }
        
        [ForeignKey("CityCode")]
        public ICollection<Citizen> Citizens { get; set; }
    }
}
