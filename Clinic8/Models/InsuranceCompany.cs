using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic8.Models
{
    public class InsuranceCompany
    {
        [Key]
        [ForeignKey(nameof(IdentityUser))]
        [Display(Name = "Id")]
        public string Id { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string ins_name { get; set; }
        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string ins_email { get; set; }
        [StringLength(15)]
        [Phone]
        [Display(Name = "Phone")]
        public string ins_phone { get; set; }
        [StringLength(50)]
        [Display(Name = "Username")]
        public string ins_username { get; set; }
        [StringLength(300)]
        [Display(Name = "Password")]
        public string ins_password { get; set; }
        [StringLength(100)]
        [Display(Name = "Address")]
        public string ins_address { get; set; }
        [StringLength(100)]
        [Display(Name = "Fax")]
        public string ins_fax { get; set; }

        public IdentityUser IdentityUser { get; set; }
    }
}
