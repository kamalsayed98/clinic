using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic8.Models
{
    public class Reminder_admin
    {
        [Key]
        [Required]
        [Display(Name = "Id")]
        public int reminder_id { get; set; }
        [Display(Name = "Date")]
        public DateTime reminder_date { get; set; }

        [StringLength(300)]
        [Display(Name = "Content")]
        public string reminder_content { get; set; }
        [StringLength(10)]
        [Display(Name = "Priority")]
        public string reminder_priority { get; set; }
        [StringLength(100)]
        [Display(Name = "Title")]
        public string reminder_title { get; set; }
        [Display(Name = "Time")]
        public DateTime reminder_time { get; set; } 
    }
}
