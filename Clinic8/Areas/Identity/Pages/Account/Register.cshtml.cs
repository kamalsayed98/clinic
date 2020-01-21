using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Clinic8.Data;
using Clinic8.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace Clinic8.Areas.Identity.Pages.Account
{

    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Username")]
            public string Username { get; set; }
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            //Admin
            public string admin_fname { get; set; }
            public string admin_mname { get; set; }
            public string admin_lname { get; set; }
            public string admin_username { get; set; }
            public string admin_password { get; set; }
            public string admin_phone { get; set; }
            public string admin_email { get; set; }


            public string Role { get; set; }
            public string dr_firstname { get; set; }
            public string dr_middlename { get; set; }
            public string dr_lastname { get; set; }
            public string dr_gender { get; set; }
            public string dr_phone { get; set; }
            public string dr_speciality { get; set; }
            public string dr_time { get; set; }
            public string dr_address { get; set; }
            public string dr_about { get; set; }
            //Assistant
            [StringLength(50)]

            public string as_fname { get; set; }
            [StringLength(50)]

            public string as_mname { get; set; }
            [StringLength(50)]

            public string as_lname { get; set; }
            public string as_gender { get; set; }
            public string as_phone { get; set; }
            public string doc_ref { get; set; }
            //Insurance company
            public string ins_name { get; set; }
            public string ins_phone { get; set; }
            public string ins_address { get; set; }
            public string ins_fax { get; set; }
            [StringLength(50)]

            public string pat_firstname { get; set; }
            [StringLength(50)]

            public string pat_middlename { get; set; }
            [StringLength(50)]

            public string pat_lastname { get; set; }

            public string pat_blood { get; set; }
            public string pat_address { get; set; }
            public string pat_gender { get; set; }
            public string pat_birthday { get; set; }
            [Phone]
            public string pat_phone { get; set; }
            public string pat_ins_ref { get; set; }



        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ViewData["doc_ref"] = new SelectList(_context.Doctor, "dr_username", "dr_username");
            ViewData["pat_ins_ref"] = new SelectList(_context.InsuranceCompany, "ins_name", "ins_name");

        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = Input.Username, Email = Input.Email };

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    if (user.Equals("Admin"))
                    {
                        var admin = new Admin
                        {
                            admin_email = Input.Email,
                            admin_fname = Input.admin_fname,
                            admin_lname = Input.admin_lname,
                            admin_mname = Input.admin_mname,
                            admin_password = Input.Password,
                            admin_phone = Input.admin_phone,
                            admin_username = Input.Username
                        };
                        _context.Admin.Add(admin);
                        await _context.SaveChangesAsync();
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                     if (!User.IsInRole("Assistant"))
                    {
                        var role = Input.Role;
                        if (!await _roleManager.RoleExistsAsync(role))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(role));
                        }
                        if (role.Equals("Doctor"))
                        {
                            var doctor = new Doctor
                            {
                                dr_password = Input.Password,
                                dr_email = Input.Email,
                                dr_firstname = Input.dr_firstname,
                                dr_middlename = Input.dr_middlename,
                                dr_lastname = Input.dr_lastname,
                                dr_geneder = Input.dr_gender,
                                dr_username = Input.Username,
                                dr_phone = Input.dr_phone,
                                dr_speciality = Input.dr_speciality,
                                dr_time = Input.dr_time,
                                dr_address = Input.dr_address,
                                dr_about = Input.dr_about,
                                Id = user.Id
                            };
                            _context.Doctor.Add(doctor);
                            await _context.SaveChangesAsync();
                            await _userManager.AddToRoleAsync(user, role);
                        }
                        else if (role == "Assistant")
                        {
                            var doctor1 = _context.Doctor.Where(e => e.dr_username == Input.doc_ref).Single();

                            var assistant = new Assistant
                            {
                                as_password = Input.Password,
                                as_email = Input.Email,
                                as_username = Input.Username,
                                as_fname = Input.as_fname,
                                as_mname = Input.as_mname,
                                as_lname = Input.as_lname,
                                doctor = doctor1,
                                ins_doc = doctor1.Id,
                                Id = user.Id
                            };
                            _context.Assistant.Add(assistant);
                            await _context.SaveChangesAsync();
                            await _userManager.AddToRoleAsync(user, role);
                        }
                        else if (role == "InsuranceCompany")
                        {
                            var insurancecompany = new InsuranceCompany
                            {
                                ins_password = Input.Password,
                                ins_email = Input.Email,
                                ins_username = Input.Username,
                                ins_name = Input.ins_name,
                                ins_phone = Input.ins_phone,
                                ins_address = Input.ins_address,
                                ins_fax = Input.ins_fax,
                                Id = user.Id
                            };
                            _context.InsuranceCompany.Add(insurancecompany);
                            await _context.SaveChangesAsync();
                            await _userManager.AddToRoleAsync(user, role);
                        }

                        return RedirectToAction("Index", "Home");

                    }
                    else//role = assistant
                    {
                        var role = "Patient";
                        if (!await _roleManager.RoleExistsAsync(role))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(role));
                        }
                        await _userManager.AddToRoleAsync(user, role);
                        var ins = _context.InsuranceCompany.Where(e => e.ins_name == Input.pat_ins_ref).Single();

                        var patient = new Patient
                        {
                            pat_password = Input.Password,
                            pat_email = Input.Email,
                            pat_username = Input.Username,
                            pat_firstname = Input.pat_firstname,
                            pat_middlename = Input.pat_middlename,
                            pat_lastname = Input.pat_lastname,
                            pat_phone = Input.pat_phone,
                            pat_address = Input.pat_address,
                            pat_blood_type = Input.pat_blood,
                            //pat_birthday = Input.pat_birthday,
                            //InsuranceCompany = ins,
                            ins_ref = ins.Id,
                            Id = user.Id
                        };
                        _context.Patient.Add(patient);
                        await _context.SaveChangesAsync();


                        return RedirectToAction("Index", "Home");
                    }

                }
                
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            ViewData["doc_ref"] = new SelectList(_context.Doctor, "dr_username", "dr_username");
            ViewData["pat_ins_ref"] = new SelectList(_context.InsuranceCompany, "ins_name", "ins_name");

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}