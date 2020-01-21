using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinic8.Models;
using Clinic8.Data;

namespace Clinic8.Controllers
{
    public class Reminder_adminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Reminder_adminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reminder_admin
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reminder_admin.ToListAsync());
        }

        // GET: Reminder_admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reminder_admin = await _context.Reminder_admin
                .FirstOrDefaultAsync(m => m.reminder_id == id);
            if (reminder_admin == null)
            {
                return NotFound();
            }

            return View(reminder_admin);
        }

        // GET: Reminder_admin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reminder_admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("reminder_id,reminder_content,reminder_priority,reminder_title,reminder_time")] Reminder_admin reminder_admin)
        {
            reminder_admin.reminder_date = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(reminder_admin);
                await _context.SaveChangesAsync();
                return RedirectToAction("Main","Admins");
            }
            return View(reminder_admin);
        }

        // GET: Reminder_admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reminder_admin = await _context.Reminder_admin.FindAsync(id);
            if (reminder_admin == null)
            {
                return NotFound();
            }
            return View(reminder_admin);
        }

        // POST: Reminder_admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("reminder_id,reminder_date,reminder_content,reminder_priority,reminder_title,reminder_time")] Reminder_admin reminder_admin)
        {
            if (id != reminder_admin.reminder_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reminder_admin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Reminder_adminExists(reminder_admin.reminder_id))
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
            return View(reminder_admin);
        }

        // GET: Reminder_admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reminder_admin = await _context.Reminder_admin
                .FirstOrDefaultAsync(m => m.reminder_id == id);
            if (reminder_admin == null)
            {
                return NotFound();
            }

            return View(reminder_admin);
        }

        // POST: Reminder_admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reminder_admin = await _context.Reminder_admin.FindAsync(id);
            _context.Reminder_admin.Remove(reminder_admin);
            await _context.SaveChangesAsync();
            return RedirectToAction("Main","Admins");
        }

        private bool Reminder_adminExists(int id)
        {
            return _context.Reminder_admin.Any(e => e.reminder_id == id);
        }
    }
}
