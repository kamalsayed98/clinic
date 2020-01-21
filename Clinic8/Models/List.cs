using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic8.Models
{
    public class List
    {
        [Key]
        [Required]
        [Range(0, 999999999999999)]
        [Display(Name = "Id")]
        public int list_id { get; set; }
        [Required]
        [Display(Name = "Doctor Id")]
        [Range(0, 999999999999999)]
        public string list_dr_id { get; set; }
        [Required]
        [Range(0, 999999999999999)]
        [Display(Name = "Patient Id")]
        public string list_pat_id { get; set; }

    }
}
