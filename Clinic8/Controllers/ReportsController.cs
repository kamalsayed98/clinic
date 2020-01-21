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

namespace Clinic8.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ReportsController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Reports
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reports.ToListAsync());
        }

        // GET: Reports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reports = await _context.Reports
                .FirstOrDefaultAsync(m => m.rep_id == id);
            if (reports == null)
            {
                return NotFound();
            }

            return View(reports);
        }

        // GET: Reports/Create
        public IActionResult Create()
        {
            ViewData["rep_pat_id"] = new SelectList(_context.Patient, "pat_username", "pat_username");

            return View();
        }

        // POST: Reports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]




        public async Task<IActionResult> Create([Bind("rep_id,rep_pat_id,rep_cons_title,rep_cons_cost")] Reports reports)
        {
            var patient = await _context.Patient.Where(e => e.pat_username == reports.rep_pat_id).SingleAsync();

            reports.rep_dr_id = (await _userManager.GetUserAsync(HttpContext.User))?.Id; ;
            reports.rep_pat_id = patient.Id;
            reports.ins_ref = patient.ins_ref;
            reports.patient = patient;
            reports.rep_cons_cost = reports.rep_cons_cost;
            reports.rep_date = DateTime.Now.ToString();
            if (ModelState.IsValid)
            {
                _context.Add(reports);
                await _context.SaveChangesAsync();
                return RedirectToAction("ViewDates","Doctors");
            }

            ViewData["rep_pat_id"] = new SelectList(_context.Patient, "pat_username", "pat_username");

            return View(reports);
        }


        // GET: Reports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reports = await _context.Reports.FindAsync(id);
            if (reports == null)
            {
                return NotFound();
            }
            return View(reports);
        }

        // POST: Reports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("rep_id,rep_pat_id,ins_ref,rep_dr_id,rep_cons_title,rep_cons_cost,rep_date")] Reports reports)
        {
            if (id != reports.rep_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reports);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportsExists(reports.rep_id))
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
            return View(reports);
        }

        // GET: Reports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reports = await _context.Reports
                .FirstOrDefaultAsync(m => m.rep_id == id);
            if (reports == null)
            {
                return NotFound();
            }

            return View(reports);
        }

        // POST: Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reports = await _context.Reports.FindAsync(id);
            _context.Reports.Remove(reports);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportsExists(int id)
        {
            return _context.Reports.Any(e => e.rep_id == id);
        }
    }
}
