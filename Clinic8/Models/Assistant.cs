using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic8.Models
{
    public class Assistant
    {
        [Key]
        [ForeignKey(nameof(IdentityUser))]
        [Display(Name = "Id")]
        public string Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Username")]
        public string as_username { get; set; }
        [Required]
        [StringLength(300)]
        [Display(Name = "Password")]
        public string as_password { get; set; } 
        [StringLength(15)]
        [Phone]
        [Display(Name = "Phone")]
        public string as_phone { get; set; }
        [StringLength(100)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string as_email { get; set; }

        [ForeignKey(nameof(Doctor))]
        public string ins_doc { get; set; }

        public Doctor doctor { get; set; }

        [StringLength(50)]
        [Display(Name = "First Name")]
        public string as_fname { get; set; }
        [StringLength(50)]
        [Display(Name = "Middle Name")]
        public string as_mname { get; set; }
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string as_lname { get; set; } 

        public IdentityUser IdentityUser { get; set; }
    }
}
