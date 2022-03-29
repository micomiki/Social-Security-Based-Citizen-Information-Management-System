using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLast.Models
{
    public class Permission
    {
        [Key]
        [Range(0,999999999)]
        public int Id { get; set; }

        [Required(ErrorMessage ="Citizen SSN Can't Be Empty")]
        public int SSN { get; set; }

        [Required]
        public int Sender { get; set; }
        [Required]
        public int Reciver { get; set; }

        [Required (ErrorMessage ="Reason Can't Be Empty")]
        [DataType(DataType.MultilineText)]
        public string Reason { get; set; }
       
        [Required(ErrorMessage ="Permission Status Can't Be Empty")]
        [StringLength(30)]
        public string Status { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "Permission Result Can't Be Empty")]
        public string Result { get; set; }
        public DateTime Request_date { get; set; }
    }
}
