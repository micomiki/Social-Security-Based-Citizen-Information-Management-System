using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLast.Models
{
    public class Information
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Inforamtion Type")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(30)]
        public string Type { get; set; }

        [ForeignKey("Info_Type")]
        public ICollection<Sector> Sector { get; set; }

    }
}
