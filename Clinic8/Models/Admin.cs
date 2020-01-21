using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic8.Models
{
    public class Admin
    {

        [Key]
        [ForeignKey(nameof(IdentityUser))]
        [Display(Name = "Id")]
        public string Id { get; set; }
        [StringLength(50)]
        [Display(Name = "Fist Name")]
        public string admin_fname { get; set; }
        [StringLength(50)]
        [Display(Name = "Middle Name")]
        public string admin_mname { get; set; }
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string admin_lname { get; set; }
        [StringLength(50)]
        [Display(Name = "Username")]
        public string admin_username { get; set; }
        [StringLength(300)]
        [Display(Name = "Password")]
        public string admin_password { get; set; }
        [StringLength(15)]
        [Phone]
        [Display(Name = "Phone")]
        public string admin_phone { get; set; }
        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string admin_email { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
