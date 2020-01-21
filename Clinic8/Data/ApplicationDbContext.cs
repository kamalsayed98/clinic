using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Clinic8.Models;

namespace Clinic8.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Clinic8.Models.Admin> Admin { get; set; }
        public DbSet<Clinic8.Models.Assistant> Assistant { get; set; }
        public DbSet<Clinic8.Models.Doctor> Doctor { get; set; }
        public DbSet<Clinic8.Models.InsuranceCompany> InsuranceCompany { get; set; }
        public DbSet<Clinic8.Models.Patient> Patient { get; set; }
        public DbSet<Clinic8.Models.Consultation> Consultation { get; set; }
        public DbSet<Clinic8.Models.Dates> Dates { get; set; }
        public DbSet<Clinic8.Models.List> List { get; set; }
        public DbSet<Clinic8.Models.Messages> Messages { get; set; }
        public DbSet<Clinic8.Models.Reports> Reports { get; set; }
        public DbSet<Clinic8.Models.Reminder_admin> Reminder_admin { get; set; }
        public DbSet<Clinic8.Models.Reminder> Reminder { get; set; }
/*        public DbSet<Clinic8.Models.Reminder_assistant> Reminder_assistant { get; set; }
        public DbSet<Clinic8.Models.Reminder_doctor> Reminder_doctor { get; set; }
        public DbSet<Clinic8.Models.Reminder_insurance> Reminder_insurance { get; set; }
        public DbSet<Clinic8.Models.Reminder_patient> Reminder_patient { get; set; }*/
    }
}
