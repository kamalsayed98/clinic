using Clinic8.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic8.Models
{
    public class assistantDates_Reminder
    {
        //public DbSet<Reminder_assistant> reminder { get; set; }
        public DbSet<Dates> dates { get; set; }

    }
}
