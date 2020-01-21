using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinic8.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "List",
                columns: table => new
                {
                    list_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    list_dr_id = table.Column<string>(nullable: false),
                    list_pat_id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_List", x => x.list_id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    m_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    m_name = table.Column<string>(maxLength: 200, nullable: true),
                    m_email = table.Column<string>(maxLength: 150, nullable: true),
                    m_subject = table.Column<string>(maxLength: 150, nullable: false),
                    m_message = table.Column<string>(nullable: false),
                    m_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.m_id);
                });

            migrationBuilder.CreateTable(
                name: "Reminder",
                columns: table => new
                {
                    reminder_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    reminder_date = table.Column<DateTime>(nullable: false),
                    reminder_content = table.Column<string>(maxLength: 300, nullable: true),
                    reminder_priority = table.Column<string>(maxLength: 10, nullable: true),
                    reminder_title = table.Column<string>(maxLength: 100, nullable: true),
                    reminder_time = table.Column<DateTime>(nullable: false),
                    reminder_ref_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminder", x => x.reminder_id);
                });

            migrationBuilder.CreateTable(
                name: "Reminder_admin",
                columns: table => new
                {
                    reminder_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    reminder_date = table.Column<DateTime>(nullable: false),
                    reminder_content = table.Column<string>(maxLength: 300, nullable: true),
                    reminder_priority = table.Column<string>(maxLength: 10, nullable: true),
                    reminder_title = table.Column<string>(maxLength: 100, nullable: true),
                    reminder_time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminder_admin", x => x.reminder_id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    admin_fname = table.Column<string>(maxLength: 50, nullable: true),
                    admin_mname = table.Column<string>(maxLength: 50, nullable: true),
                    admin_lname = table.Column<string>(maxLength: 50, nullable: true),
                    admin_username = table.Column<string>(maxLength: 50, nullable: true),
                    admin_password = table.Column<string>(maxLength: 300, nullable: true),
                    admin_phone = table.Column<string>(maxLength: 15, nullable: true),
                    admin_email = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admin_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    dr_firstname = table.Column<string>(maxLength: 50, nullable: false),
                    dr_middlename = table.Column<string>(maxLength: 50, nullable: true),
                    dr_lastname = table.Column<string>(maxLength: 50, nullable: true),
                    dr_display_name = table.Column<string>(maxLength: 100, nullable: true),
                    dr_geneder = table.Column<string>(maxLength: 10, nullable: true),
                    dr_username = table.Column<string>(maxLength: 50, nullable: true),
                    dr_password = table.Column<string>(maxLength: 300, nullable: true),
                    dr_phone = table.Column<string>(maxLength: 32, nullable: true),
                    dr_speciality = table.Column<string>(maxLength: 100, nullable: true),
                    dr_time = table.Column<string>(maxLength: 100, nullable: true),
                    dr_email = table.Column<string>(maxLength: 100, nullable: true),
                    dr_address = table.Column<string>(nullable: true),
                    dr_about = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceCompany",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ins_name = table.Column<string>(maxLength: 100, nullable: false),
                    ins_email = table.Column<string>(maxLength: 50, nullable: true),
                    ins_phone = table.Column<string>(maxLength: 15, nullable: true),
                    ins_username = table.Column<string>(maxLength: 50, nullable: true),
                    ins_password = table.Column<string>(maxLength: 300, nullable: true),
                    ins_address = table.Column<string>(maxLength: 100, nullable: true),
                    ins_fax = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceCompany_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assistant",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    as_username = table.Column<string>(maxLength: 50, nullable: false),
                    as_password = table.Column<string>(maxLength: 300, nullable: false),
                    as_phone = table.Column<string>(maxLength: 15, nullable: true),
                    as_email = table.Column<string>(maxLength: 100, nullable: true),
                    ins_doc = table.Column<string>(nullable: true),
                    doctorId = table.Column<string>(nullable: true),
                    as_fname = table.Column<string>(maxLength: 50, nullable: true),
                    as_mname = table.Column<string>(maxLength: 50, nullable: true),
                    as_lname = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assistant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assistant_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assistant_Doctor_doctorId",
                        column: x => x.doctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    pat_firstname = table.Column<string>(maxLength: 50, nullable: true),
                    pat_middlename = table.Column<string>(maxLength: 50, nullable: true),
                    pat_lastname = table.Column<string>(maxLength: 50, nullable: true),
                    pat_geneder = table.Column<string>(maxLength: 10, nullable: true),
                    pat_username = table.Column<string>(maxLength: 50, nullable: true),
                    pat_password = table.Column<string>(maxLength: 300, nullable: true),
                    pat_phone = table.Column<string>(maxLength: 32, nullable: true),
                    pat_birthday = table.Column<DateTime>(nullable: false),
                    pat_email = table.Column<string>(maxLength: 100, nullable: true),
                    pat_address = table.Column<string>(nullable: true),
                    pat_blood_type = table.Column<string>(maxLength: 4, nullable: true),
                    ins_ref = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patient_InsuranceCompany_ins_ref",
                        column: x => x.ins_ref,
                        principalTable: "InsuranceCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Consultation",
                columns: table => new
                {
                    cons_id = table.Column<string>(nullable: false),
                    ins_pat = table.Column<string>(nullable: true),
                    patientId = table.Column<string>(nullable: true),
                    doctorId = table.Column<string>(nullable: true),
                    cons_title = table.Column<string>(maxLength: 100, nullable: true),
                    cons_type = table.Column<string>(maxLength: 50, nullable: true),
                    cons_d = table.Column<DateTime>(nullable: false),
                    cons_symptoms = table.Column<string>(nullable: true),
                    cons_diagnosis = table.Column<string>(nullable: true),
                    cons_temp = table.Column<string>(maxLength: 5, nullable: true),
                    cons_blood_presure = table.Column<string>(maxLength: 5, nullable: true),
                    cons_cost = table.Column<string>(maxLength: 10, nullable: true),
                    cons_treatment = table.Column<string>(nullable: true),
                    ins_ref = table.Column<string>(nullable: true),
                    insuranceCompanyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultation", x => x.cons_id);
                    table.ForeignKey(
                        name: "FK_Consultation_Doctor_doctorId",
                        column: x => x.doctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consultation_InsuranceCompany_insuranceCompanyId",
                        column: x => x.insuranceCompanyId,
                        principalTable: "InsuranceCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consultation_Patient_patientId",
                        column: x => x.patientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dates",
                columns: table => new
                {
                    date_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    pat_rel = table.Column<string>(nullable: true),
                    doc_rel = table.Column<string>(nullable: true),
                    patirntId = table.Column<string>(nullable: true),
                    doctorId = table.Column<string>(nullable: true),
                    date_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dates", x => x.date_id);
                    table.ForeignKey(
                        name: "FK_Dates_Doctor_doctorId",
                        column: x => x.doctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dates_Patient_patirntId",
                        column: x => x.patirntId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    rep_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    rep_pat_id = table.Column<string>(nullable: true),
                    patientId = table.Column<string>(nullable: true),
                    ins_ref = table.Column<string>(nullable: true),
                    rep_dr_id = table.Column<string>(nullable: true),
                    rep_cons_title = table.Column<string>(maxLength: 200, nullable: true),
                    rep_cons_cost = table.Column<string>(maxLength: 20, nullable: true),
                    rep_date = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.rep_id);
                    table.ForeignKey(
                        name: "FK_Reports_Patient_patientId",
                        column: x => x.patientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Assistant_doctorId",
                table: "Assistant",
                column: "doctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_doctorId",
                table: "Consultation",
                column: "doctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_insuranceCompanyId",
                table: "Consultation",
                column: "insuranceCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_patientId",
                table: "Consultation",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_Dates_doctorId",
                table: "Dates",
                column: "doctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Dates_patirntId",
                table: "Dates",
                column: "patirntId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_ins_ref",
                table: "Patient",
                column: "ins_ref");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_patientId",
                table: "Reports",
                column: "patientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Assistant");

            migrationBuilder.DropTable(
                name: "Consultation");

            migrationBuilder.DropTable(
                name: "Dates");

            migrationBuilder.DropTable(
                name: "List");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Reminder");

            migrationBuilder.DropTable(
                name: "Reminder_admin");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "InsuranceCompany");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
