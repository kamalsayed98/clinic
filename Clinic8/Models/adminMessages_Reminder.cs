using Clinic8.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic8.Models
{
    public class adminMessages_Reminder
    {
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Reminder_admin> reminder_Admins { get; set; }

    }
}
