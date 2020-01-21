using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Clinic8.Models;

namespace Clinic8.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            return RedirectToRoute(GetRole());
        }

        public IActionResult Privacy()
        {
            return View();
        }
       
        public IActionResult Index1()
        {
            return View();
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }

        private string GetRole()
        {
            if (User.IsInRole("Admin")) return "Admin";
            if (User.IsInRole("Doctor")) return "Doctor";
            if (User.IsInRole("Assistant")) return "Assistant";
            if (User.IsInRole("Patient")) return "Patient";
            if (User.IsInRole("InsuranceCompany")) return "Insurance";
            return "Index1";
        }
    }
}
