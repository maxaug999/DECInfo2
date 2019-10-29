﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DECInfo2.Models;

namespace DECInfo2.Controllers
{
    public class ProfsController : Controller
    {
        private readonly DECInfo2Context _context;

        public ProfsController(DECInfo2Context context)
        {
            _context = context;
        }

        // GET: Profs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prof.ToListAsync());
        }

        // GET: Profs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prof = await _context.Prof
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prof == null)
            {
                return NotFound();
            }

            return View(prof);
        }

        // GET: Profs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Permanent")] Prof prof)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prof);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prof);
        }

        // GET: Profs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prof = await _context.Prof.FindAsync(id);
            if (prof == null)
            {
                return NotFound();
            }
            return View(prof);
        }

        // POST: Profs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Permanent")] Prof prof)
        {
            if (id != prof.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prof);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfExists(prof.Id))
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
            return View(prof);
        }

        // GET: Profs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prof = await _context.Prof
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prof == null)
            {
                return NotFound();
            }

            return View(prof);
        }

        // POST: Profs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prof = await _context.Prof.FindAsync(id);
            _context.Prof.Remove(prof);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfExists(int id)
        {
            return _context.Prof.Any(e => e.Id == id);
        }
    }
}
