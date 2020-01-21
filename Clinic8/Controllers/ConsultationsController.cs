using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinic8.Models;
using Clinic8.Data;
using Microsoft.AspNetCore.Identity;

namespace Clinic8.Controllers
{
    public class ConsultationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ConsultationsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Consultations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Consultation.ToListAsync());
        }

        // GET: Consultations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultation = await _context.Consultation
                .FirstOrDefaultAsync(m => m.cons_id == id);
            if (consultation == null)
            {
                return NotFound();
            }

            return View(consultation);
        }

        // GET: Consultations/Create
        public IActionResult Create()
        {
            ViewData["ins_pat"] = new SelectList(_context.Patient, "pat_username", "pat_username");
            return View();
        }

        // POST: Consultations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cons_id,ins_pat,cons_title,cons_type,cons_d,cons_symptoms,cons_diagnosis,cons_temp,cons_blood_presure,cons_cost,cons_treatment")] Consultation consultation)
        {
            var patient = _context.Patient.Where(e => e.pat_username == consultation.ins_pat).Single();
            
                var  id = (await _userManager.GetUserAsync(HttpContext.User))?.Id;

            consultation.cons_d = DateTime.Now;
            consultation.patient = patient;
            consultation.ins_pat = patient.Id;
            consultation.ins_ref = patient.ins_ref;
            consultation.doctor = _context.Doctor.Where(e => e.Id == id).Single();
            if (ModelState.IsValid)
            {
                
                _context.Add(consultation);
                await _context.SaveChangesAsync();
                return RedirectToAction("ViewConsultation","Doctor");
            }
            ViewData["ins_pat"] = new SelectList(_context.Patient, "pat_username", "pat_username");

            return View(consultation);
        }

        // GET: Consultations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {


            if (id == null)
            {
                return NotFound();
            }

            var consultation = await _context.Consultation.FindAsync(id);
            if (consultation == null)
            {
                return NotFound();
            }
            var p= _context.Patient.Where(e => e.Id == consultation.ins_pat).Single();
            var x= p.pat_firstname + " " + p.pat_lastname;
            ViewData["pat"] = x;
            return View(consultation);
        }

        // POST: Consultations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("cons_id,ins_pat,cons_title,cons_type,cons_d,cons_symptoms,cons_diagnosis,cons_temp,cons_blood_presure,cons_cost,cons_treatment,ins_ref")] Consultation consultation)
        {
            if (id != consultation.cons_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultationExists(consultation.cons_id))
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
            return View(consultation);
        }

        // GET: Consultations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultation = await _context.Consultation
                .FirstOrDefaultAsync(m => m.cons_id == id);
            if (consultation == null)
            {
                return NotFound();
            }

            return View(consultation);
        }

        // POST: Consultations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var consultation = await _context.Consultation.FindAsync(id);
            _context.Consultation.Remove(consultation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultationExists(string id)
        {
            return _context.Consultation.Any(e => e.cons_id == id);
        }
    }
}
