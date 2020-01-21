using Clinic8.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic8.Models
{
    public class Reports
    {
        [Key]
        [Display(Name = "Id")]
        public int rep_id { get; set; }
        [ForeignKey(nameof(Patient))]
        [Display(Name = "Patient Id")]
        public string rep_pat_id { get; set; }
        public Patient  patient { get; set; }
        [ForeignKey(nameof(InsuranceCompany))]
        public string ins_ref { get; set; }

        [ForeignKey(nameof(Doctor))]
        [Display(Name = "Doctor Id")]
        public string rep_dr_id { get; set; }
        [StringLength(200)]
        [Display(Name = "Consultation Title")]
        public string rep_cons_title { get; set; }
        [StringLength(20)]
        [Display(Name = "Consultation Cost")]
        public string rep_cons_cost { get; set; }
        [StringLength(50)]
        [Display(Name = "Date")]
        public string rep_date { get; set; }

    }
}
