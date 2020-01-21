﻿// <auto-generated />
using System;
using Clinic8.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Clinic8.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190708040604_anything1")]
    partial class anything1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Clinic8.Models.Admin", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("admin_email")
                        .HasMaxLength(50);

                    b.Property<string>("admin_fname")
                        .HasMaxLength(50);

                    b.Property<string>("admin_lname")
                        .HasMaxLength(50);

                    b.Property<string>("admin_mname")
                        .HasMaxLength(50);

                    b.Property<string>("admin_password")
                        .HasMaxLength(300);

                    b.Property<string>("admin_phone")
                        .HasMaxLength(15);

                    b.Property<string>("admin_username")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("Clinic8.Models.Assistant", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("as_email")
                        .HasMaxLength(100);

                    b.Property<string>("as_fname")
                        .HasMaxLength(50);

                    b.Property<string>("as_lname")
                        .HasMaxLength(50);

                    b.Property<string>("as_mname")
                        .HasMaxLength(50);

                    b.Property<string>("as_password")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("as_phone")
                        .HasMaxLength(15);

                    b.Property<string>("as_username")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("doctorId");

                    b.Property<string>("ins_doc");

                    b.HasKey("Id");

                    b.HasIndex("doctorId");

                    b.ToTable("Assistant");
                });

            modelBuilder.Entity("Clinic8.Models.Consultation", b =>
                {
                    b.Property<string>("cons_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("cons_blood_presure")
                        .HasMaxLength(5);

                    b.Property<string>("cons_cost")
                        .HasMaxLength(10);

                    b.Property<DateTime>("cons_d");

                    b.Property<string>("cons_diagnosis");

                    b.Property<string>("cons_symptoms");

                    b.Property<string>("cons_temp")
                        .HasMaxLength(5);

                    b.Property<string>("cons_title")
                        .HasMaxLength(100);

                    b.Property<string>("cons_treatment");

                    b.Property<string>("cons_type")
                        .HasMaxLength(50);

                    b.Property<string>("doctorId");

                    b.Property<string>("ins_pat");

                    b.Property<string>("ins_ref");

                    b.Property<string>("insuranceCompanyId");

                    b.Property<string>("patientId");

                    b.HasKey("cons_id");

                    b.HasIndex("doctorId");

                    b.HasIndex("insuranceCompanyId");

                    b.HasIndex("patientId");

                    b.ToTable("Consultation");
                });

            modelBuilder.Entity("Clinic8.Models.Dates", b =>
                {
                    b.Property<int>("date_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("date_date");

                    b.Property<string>("doc_rel");

                    b.Property<string>("doctorId");

                    b.Property<string>("pat_rel");

                    b.Property<string>("patirntId");

                    b.HasKey("date_id");

                    b.HasIndex("doctorId");

                    b.HasIndex("patirntId");

                    b.ToTable("Dates");
                });

            modelBuilder.Entity("Clinic8.Models.Doctor", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("dr_about");

                    b.Property<string>("dr_address");

                    b.Property<string>("dr_display_name")
                        .HasMaxLength(100);

                    b.Property<string>("dr_email")
                        .HasMaxLength(100);

                    b.Property<string>("dr_firstname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("dr_geneder")
                        .HasMaxLength(10);

                    b.Property<string>("dr_lastname")
                        .HasMaxLength(50);

                    b.Property<string>("dr_middlename")
                        .HasMaxLength(50);

                    b.Property<string>("dr_password")
                        .HasMaxLength(300);

                    b.Property<string>("dr_phone")
                        .HasMaxLength(32);

                    b.Property<string>("dr_speciality")
                        .HasMaxLength(100);

                    b.Property<string>("dr_time")
                        .HasMaxLength(100);

                    b.Property<string>("dr_username")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("Clinic8.Models.InsuranceCompany", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ins_address")
                        .HasMaxLength(100);

                    b.Property<string>("ins_email")
                        .HasMaxLength(50);

                    b.Property<string>("ins_fax")
                        .HasMaxLength(100);

                    b.Property<string>("ins_name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ins_password")
                        .HasMaxLength(300);

                    b.Property<string>("ins_phone")
                        .HasMaxLength(15);

                    b.Property<string>("ins_username")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("InsuranceCompany");
                });

            modelBuilder.Entity("Clinic8.Models.List", b =>
                {
                    b.Property<int>("list_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("list_dr_id")
                        .IsRequired();

                    b.Property<string>("list_pat_id")
                        .IsRequired();

                    b.HasKey("list_id");

                    b.ToTable("List");
                });

            modelBuilder.Entity("Clinic8.Models.Messages", b =>
                {
                    b.Property<int>("m_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("m_date");

                    b.Property<string>("m_email")
                        .HasMaxLength(150);

                    b.Property<string>("m_message")
                        .IsRequired();

                    b.Property<string>("m_name")
                        .HasMaxLength(200);

                    b.Property<string>("m_subject")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("m_id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Clinic8.Models.Patient", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ins_ref");

                    b.Property<string>("pat_address");

                    b.Property<int>("pat_birthday");

                    b.Property<string>("pat_blood_type")
                        .HasMaxLength(4);

                    b.Property<string>("pat_email")
                        .HasMaxLength(100);

                    b.Property<string>("pat_firstname")
                        .HasMaxLength(50);

                    b.Property<string>("pat_geneder")
                        .HasMaxLength(10);

                    b.Property<string>("pat_lastname")
                        .HasMaxLength(50);

                    b.Property<string>("pat_middlename")
                        .HasMaxLength(50);

                    b.Property<string>("pat_password")
                        .HasMaxLength(300);

                    b.Property<string>("pat_phone")
                        .HasMaxLength(32);

                    b.Property<string>("pat_username")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("ins_ref");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("Clinic8.Models.Reminder", b =>
                {
                    b.Property<int>("reminder_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("reminder_content")
                        .HasMaxLength(300);

                    b.Property<DateTime>("reminder_date");

                    b.Property<string>("reminder_priority")
                        .HasMaxLength(10);

                    b.Property<string>("reminder_ref_id");

                    b.Property<DateTime>("reminder_time");

                    b.Property<string>("reminder_title")
                        .HasMaxLength(100);

                    b.HasKey("reminder_id");

                    b.ToTable("Reminder");
                });

            modelBuilder.Entity("Clinic8.Models.Reminder_admin", b =>
                {
                    b.Property<int>("reminder_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("reminder_content")
                        .HasMaxLength(300);

                    b.Property<DateTime>("reminder_date");

                    b.Property<string>("reminder_priority")
                        .HasMaxLength(10);

                    b.Property<DateTime>("reminder_time");

                    b.Property<string>("reminder_title")
                        .HasMaxLength(100);

                    b.HasKey("reminder_id");

                    b.ToTable("Reminder_admin");
                });

            modelBuilder.Entity("Clinic8.Models.Reports", b =>
                {
                    b.Property<long>("rep_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ins_ref");

                    b.Property<string>("patientId");

                    b.Property<string>("rep_cons_cost")
                        .HasMaxLength(20);

                    b.Property<string>("rep_cons_title")
                        .HasMaxLength(200);

                    b.Property<string>("rep_date")
                        .HasMaxLength(50);

                    b.Property<string>("rep_dr_id");

                    b.Property<string>("rep_pat_id");

                    b.HasKey("rep_id");

                    b.HasIndex("patientId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Clinic8.Models.Admin", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Clinic8.Models.Assistant", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Clinic8.Models.Doctor", "doctor")
                        .WithMany()
                        .HasForeignKey("doctorId");
                });

            modelBuilder.Entity("Clinic8.Models.Consultation", b =>
                {
                    b.HasOne("Clinic8.Models.Doctor", "doctor")
                        .WithMany()
                        .HasForeignKey("doctorId");

                    b.HasOne("Clinic8.Models.InsuranceCompany", "insuranceCompany")
                        .WithMany()
                        .HasForeignKey("insuranceCompanyId");

                    b.HasOne("Clinic8.Models.Patient", "patient")
                        .WithMany()
                        .HasForeignKey("patientId");
                });

            modelBuilder.Entity("Clinic8.Models.Dates", b =>
                {
                    b.HasOne("Clinic8.Models.Doctor", "doctor")
                        .WithMany()
                        .HasForeignKey("doctorId");

                    b.HasOne("Clinic8.Models.Patient", "patirnt")
                        .WithMany()
                        .HasForeignKey("patirntId");
                });

            modelBuilder.Entity("Clinic8.Models.Doctor", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Clinic8.Models.InsuranceCompany", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Clinic8.Models.Patient", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Clinic8.Models.InsuranceCompany", "InsuranceCompany")
                        .WithMany()
                        .HasForeignKey("ins_ref");
                });

            modelBuilder.Entity("Clinic8.Models.Reports", b =>
                {
                    b.HasOne("Clinic8.Models.Patient", "patient")
                        .WithMany()
                        .HasForeignKey("patientId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
