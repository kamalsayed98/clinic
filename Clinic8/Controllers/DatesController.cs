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
    public class DatesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DatesController(ApplicationDbContext context,UserManager<IdentityUser>userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Dates
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dates.ToListAsync());
        }

        // GET: Dates/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var dates = await _context.Dates
        //        .FirstOrDefaultAsync(m => m.date_id == id);
        //    if (dates == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(dates);
        //}
        public IActionResult Details()
        {
            return View();
        }
        [Authorize(Roles = "Assistant,Doctor")]

        // GET: Dates/Create
        public IActionResult Create()
        {
            ViewData["doc_rel"] = new SelectList(_context.Doctor, "dr_username", "dr_username");
            ViewData["pat_rel"] = new SelectList(_context.Patient, "pat_username", "pat_username");

            return View();
        }
        [Authorize(Roles = "Assistant,Doctor")]

        // POST: Dates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("date_id,pat_rel,doc_rel,date_date")] Dates dates)
        {
            if (User.IsInRole("Doctor"))
            {
                var doctorId = (await _userManager.GetUserAsync(HttpContext.User))?.Id;
                var doctor = _context.Doctor.Where(e => e.Id == doctorId).Single();
                var patient = _context.Patient.Where(e => e.pat_username == dates.pat_rel).Single();
                dates.doctor = doctor;
                dates.patirnt = patient;
                dates.doc_rel = doctorId;
                dates.pat_rel = patient.Id;

                if (ModelState.IsValid)
                {
                    _context.Add(dates);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            if (User.IsInRole("Assistant"))
            {
                var assistantId = (await _userManager.GetUserAsync(HttpContext.User))?.Id;
                var assistant = _context.Assistant.Where(e => e.Id == assistantId).Single();
                var doctorId = assistant.ins_doc;
                var doctor = _context.Doctor.Where(e => e.Id == doctorId).Single();
                var patient = _context.Patient.Where(e => e.pat_username == dates.pat_rel).Single();
                dates.doctor = doctor;
                dates.patirnt = patient;
                dates.doc_rel = doctorId;
                dates.pat_rel = patient.Id;

                if (ModelState.IsValid)
                {
                    _context.Add(dates);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            ViewData["doc_rel"] = new SelectList(_context.Doctor, "dr_username", "dr_username");
            ViewData["pat_rel"] = new SelectList(_context.Patient, "pat_username", "pat_username");

            return View(dates);
        }

        // GET: Dates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dates = await _context.Dates.FindAsync(id);
            if (dates == null)
            {
                return NotFound();
            }
            return View(dates);
        }

        // POST: Dates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("date_id,pat_rel,doc_rel,date_date")] Dates dates)
        {
            if (id != dates.date_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dates);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatesExists(dates.date_id))
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
            return View(dates);
        }

        // GET: Dates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dates = await _context.Dates
                .FirstOrDefaultAsync(m => m.date_id == id);
            if (dates == null)
            {
                return NotFound();
            }

            return View(dates);
        }

        // POST: Dates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dates = await _context.Dates.FindAsync(id);
            _context.Dates.Remove(dates);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatesExists(int id)
        {
            return _context.Dates.Any(e => e.date_id == id);
        }
    }
}
