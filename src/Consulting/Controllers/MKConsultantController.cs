using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Consulting.Models;

namespace Consulting.Controllers
{
    public class MKConsultantController : Controller
    {
        private readonly ConsultingContext _context;

        public MKConsultantController(ConsultingContext context)
        {
            _context = context;    
        }

        // GET: MKConsultant
        public async Task<IActionResult> Index()
        {
            return View(await _context.Consultant.ToListAsync());
        }

        // GET: MKConsultant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultant = await _context.Consultant.SingleOrDefaultAsync(m => m.ConsultantId == id);
            if (consultant == null)
            {
                return NotFound();
            }

            return View(consultant);
        }

        // GET: MKConsultant/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MKConsultant/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConsultantId,Category,DateHired,FirstName,Gender,HourlyRate,LastName,Partner")] Consultant consultant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultant);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(consultant);
        }

        // GET: MKConsultant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultant = await _context.Consultant.SingleOrDefaultAsync(m => m.ConsultantId == id);
            if (consultant == null)
            {
                return NotFound();
            }
            return View(consultant);
        }

        // POST: MKConsultant/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConsultantId,Category,DateHired,FirstName,Gender,HourlyRate,LastName,Partner")] Consultant consultant)
        {
            if (id != consultant.ConsultantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultantExists(consultant.ConsultantId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(consultant);
        }

        // GET: MKConsultant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultant = await _context.Consultant.SingleOrDefaultAsync(m => m.ConsultantId == id);
            if (consultant == null)
            {
                return NotFound();
            }

            return View(consultant);
        }

        // POST: MKConsultant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consultant = await _context.Consultant.SingleOrDefaultAsync(m => m.ConsultantId == id);
            _context.Consultant.Remove(consultant);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ConsultantExists(int id)
        {
            return _context.Consultant.Any(e => e.ConsultantId == id);
        }
    }
}
