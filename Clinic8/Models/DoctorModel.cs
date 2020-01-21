using Clinic8.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic8.Models
{
    public class DoctorModel
    {
      //  public DbSet<Reminder_doctor> reminder_Doctor { get; set; }
        public DbSet<Dates> Dates { get; set; }
        public DbSet<Consultation> Consultation { get; set; }
        public DbSet<Patient> Patients { get; set; }

    }
}
