using Clinic8.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic8.Models
{
    public class insuranceReport_Reminder
    {
        public DbSet<Reports> reports { get; set; }
        //public DbSet<Reminder_insurance> reminder_insurance { get; set; }

    }
}
