using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic8.Models
{
    public class Patient
    {
        [Key]
        [ForeignKey(nameof(IdentityUser))]
        public string Id { get; set; }
        [StringLength(50)]
        [Display(Name = "Fist Name")]
        public string pat_firstname { get; set; }
        [StringLength(50)]
        [Display(Name = "Middle Name")]
        public string pat_middlename { get; set; }
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string pat_lastname { get; set; } 
        [StringLength(10)]
        [Display(Name = "Geneder")]
        public string pat_geneder { get; set; }
        [StringLength(50)]
        [Display(Name = "Username")]
        public string pat_username { get; set; }
        [StringLength(300)]
        [Display(Name = "Password")]
        public string pat_password { get; set; }
        [StringLength(32)]
        [Phone]
        [Display(Name = "Phone")]
        public string pat_phone { get; set; } 

        [Display(Name = "Birthday")]
        public DateTime pat_birthday { get; set; }

        [StringLength(100)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string pat_email { get; set; }

        [Display(Name = "Address")]
        public string pat_address { get; set; }
        [StringLength(4)]
        [Display(Name = "Blood Type")]
        public string pat_blood_type { get; set; }
        [ForeignKey(nameof(InsuranceCompany))]
        public string ins_ref { get; set; }

        [Display(Name = "Insurance Company")]
        public InsuranceCompany InsuranceCompany { get; set; } 

        public IdentityUser IdentityUser { get; set; }

    }
}
