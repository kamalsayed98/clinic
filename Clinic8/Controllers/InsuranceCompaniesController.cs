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
    public class InsuranceCompaniesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public InsuranceCompaniesController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [Authorize(Roles = "InsuranceCompany")]

        public async Task<IActionResult> Main()
        {
            var id = (await _userManager.GetUserAsync(HttpContext.User))?.Id;
            ViewData["id"] = id;
            var reports = await _context.Reports
                .Include(r => r.patient)
                .ToListAsync();
            foreach (var item in reports)
            {
                if(item.patient.ins_ref != id)
                {
                    reports.Remove(item);
                }
            }
            return View(reports);
        }

        [Authorize(Roles = "Admin")]

        // GET: InsuranceCompanies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.InsuranceCompany.Include(i => i.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: InsuranceCompanies/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceCompany = await _context.InsuranceCompany
                .Include(i => i.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuranceCompany == null)
            {
                return NotFound();
            }

            return View(insuranceCompany);
        }

        // GET: InsuranceCompanies/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: InsuranceCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ins_name,ins_email,ins_phone,ins_username,ins_password,ins_address,ins_fax")] InsuranceCompany insuranceCompany)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insuranceCompany);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", insuranceCompany.Id);
            return View(insuranceCompany);
        }

        // GET: InsuranceCompanies/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceCompany = await _context.InsuranceCompany.FindAsync(id);
            if (insuranceCompany == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", insuranceCompany.Id);
            return View(insuranceCompany);
        }

        // POST: InsuranceCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,ins_name,ins_email,ins_phone,ins_username,ins_password,ins_address,ins_fax")] InsuranceCompany insuranceCompany)
        {
            if (id != insuranceCompany.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insuranceCompany);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsuranceCompanyExists(insuranceCompany.Id))
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
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", insuranceCompany.Id);
            return View(insuranceCompany);
        }

        // GET: InsuranceCompanies/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceCompany = await _context.InsuranceCompany
                .Include(i => i.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuranceCompany == null)
            {
                return NotFound();
            }

            return View(insuranceCompany);
        }

        // POST: InsuranceCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var insuranceCompany = await _context.InsuranceCompany.FindAsync(id);
            _context.InsuranceCompany.Remove(insuranceCompany);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsuranceCompanyExists(string id)
        {
            return _context.InsuranceCompany.Any(e => e.Id == id);
        }
    }
}
