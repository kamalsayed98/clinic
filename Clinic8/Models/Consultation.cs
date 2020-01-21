using Clinic8.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic8.Models
{
    public class Consultation
    {
        [Key]
        [Display(Name = "Id")]
        public string cons_id { get; set; }
        [ForeignKey(nameof(Patient))]
        public string ins_pat { get; set; }

        public Patient patient { get; set; }

        public Doctor doctor { get; set; }

        [StringLength(100)]
        [Display(Name = "Title")]
        public string cons_title { get; set; }
        [StringLength(50)]
        [Display(Name = "Type")]
        public string cons_type { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime cons_d { get; set; }
        [Display(Name = "Symptoms")]
        public string cons_symptoms { get; set; }
        [Display(Name = "Diagnosis")]
        public string cons_diagnosis { get; set; }
        [StringLength(5)]
        [Display(Name = "Temp")]
        public string cons_temp { get; set; }
        [StringLength(5)]
        [Display(Name = "Blood Presure")]
        public string cons_blood_presure { get; set; }
        [StringLength(10)]
        [Display(Name = "Cost")]
        public string cons_cost { get; set; }
        [Display(Name = "Treatment")]
        public string cons_treatment { get; set; }
        [ForeignKey(nameof(InsuranceCompany))]
        public string ins_ref { get; set; }

        public InsuranceCompany insuranceCompany { get; set; }


    }
}
