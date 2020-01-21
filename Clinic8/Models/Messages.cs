using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic8.Models
{
    public class Messages
    {
        [Key]
        [Display(Name = "Id")]
        public int m_id { get; set; }
        [StringLength(200)]
        [Display(Name = "Name")]
        public string m_name { get; set; }
        [StringLength(150)]
        [Display(Name = "Email")]
        public string m_email { get; set; }
        [Required]
        [StringLength(150)]
        [Display(Name = "Subject")]
        public string m_subject { get; set; }
        [Required]
        [Display(Name = "Message")]
        public string m_message { get; set; }

        public DateTime m_date { get; set; }


    }
}
