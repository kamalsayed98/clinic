using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic8.Models
{
    public class Doctor
    {
        [Key]
        [ForeignKey(nameof(IdentityUser))]
        [Display(Name = "Id")]
        public string Id { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "First Name")]
        public string dr_firstname { get; set; }

        [StringLength(50)]
        [Display(Name = "Middle Name")]
        public string dr_middlename { get; set; }

        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string dr_lastname { get; set; }

        [StringLength(100)]
        [Display(Name = "Display Name")]
        public string dr_display_name { get; set; }

        [StringLength(10)]
        [Display(Name = "Geneder")]
        public string dr_geneder { get; set; }

        [StringLength(50)]
        [Display(Name = "Username")]
        public string dr_username { get; set; }

        [StringLength(300)]
        [Display(Name = "Password")]
        public string dr_password { get; set; }

        [StringLength(32)]
        [Phone]
        [Display(Name = "Phone")]
        public String dr_phone { get; set; } 

        [StringLength(100)]
        [Display(Name = "Speciality")]
        public string dr_speciality { get; set; }

        [StringLength(100)]
        [Display(Name = "Time")]
        public string dr_time { get; set; }

        [StringLength(100)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string dr_email { get; set; }

        [Display(Name = "Address")]
        public string dr_address { get; set; }

        [Display(Name = "About")]
        public string dr_about { get; set; }

        public IdentityUser IdentityUser { get; set; }

    }
}
