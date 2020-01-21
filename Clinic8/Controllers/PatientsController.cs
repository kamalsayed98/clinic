using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinic8.Data;
using Clinic8.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Clinic8.Controllers
{
    public class PatientsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public PatientsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Patient")]

        public IActionResult SearchDoctor(string s ="")
        {
            if(s == "")
            {
                return View();
            }
            ViewData["searching"] = true;
            var ds = _context.Doctor.Where(e => e.dr_username.StartsWith(s));
            if(ds.Any())
            {
                var d = ds.Single();
                ViewData["searching"] = false;
                return View(d);

            }
            return View();
        }

        [HttpPost]
        public JsonResult Search1(String Prefix)
        {
            var list = new List<String>();
            var doctorsList = _context.Doctor;
            foreach (var item in doctorsList)
            {
                list.Add(item.dr_username);
            }
            var doctorList = (from M in list
                              where M.StartsWith(Prefix)
                              select new { M });
            return Json(doctorList);
        }
        [Authorize(Roles = "Patient")]

        public async Task<IActionResult> ViewTreatment()
        {
            var consultaion = _context.Consultation.ToList();
            ViewData["id"] = (await _userManager.GetUserAsync(HttpContext.User))?.Id;
            return View(consultaion);
        }
        [Authorize(Roles = "Patient")]
<<<<<<< HEAD

=======
>>>>>>> f997cdbcc9ce54b2f83b3db478c5039da256aa4f
        public async Task<IActionResult> ViewDates()
        {
            var dates = _context.Dates.ToList();
            ViewData["id"] = (await _userManager.GetUserAsync(HttpContext.User))?.Id;
            return View(dates);
        }
        [Authorize(Roles = "Assistant")]

        // GET: Patients
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Patient.Include(p => p.IdentityUser).Include(p => p.InsuranceCompany);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient
                .Include(p => p.IdentityUser)
                .Include(p => p.InsuranceCompany)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["ins_ref"] = new SelectList(_context.InsuranceCompany, "Id", "Id");
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,pat_firstname,pat_middlename,pat_lastname,pat_geneder,pat_username,pat_password,pat_phone,pat_birthday,pat_email,pat_address,pat_blood_type,ins_ref")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", patient.Id);
            ViewData["ins_ref"] = new SelectList(_context.InsuranceCompany, "Id", "Id", patient.ins_ref);
            return View(patient);
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", patient.Id);
            ViewData["ins_ref"] = new SelectList(_context.InsuranceCompany, "ins_name", "ins_name", patient.ins_ref);
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,pat_firstname,pat_middlename,pat_lastname,pat_geneder,pat_username,pat_password,pat_phone,pat_birthday,pat_email,pat_address,pat_blood_type,ins_ref")] Patient patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }
            var ins = _context.InsuranceCompany.Where(e => e.ins_name == patient.ins_ref).Single();
            patient.ins_ref = ins.Id;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", patient.Id);
            ViewData["ins_ref"] = new SelectList(_context.InsuranceCompany, "ins_name", "ins_name", patient.ins_ref);
            return View(patient);
        }

        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient
                .Include(p => p.IdentityUser)
                .Include(p => p.InsuranceCompany)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var patient = await _context.Patient.FindAsync(id);
            _context.Patient.Remove(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(string id)
        {
            return _context.Patient.Any(e => e.Id == id);
        }
    }
}
