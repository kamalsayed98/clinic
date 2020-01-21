using Clinic8.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic8.Models
{
    public class Dates
    {
        [Key]
        [Display(Name = "Id")]
        public int date_id { get; set; }
        [ForeignKey(nameof(Patient))]
        public string pat_rel { get; set; }
        [ForeignKey(nameof(Doctor))]
        public string doc_rel { get; set; }
        public Patient patirnt { get; set; }
        public Doctor doctor { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime date_date { get; set; } 

    }
}
