using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IncIncEntityUserAccounts.Contexts;
using IncIncEntityUserAccounts.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace IncIncEntityUserAccounts.Controllers
{
    [Authorize]
    public class WorkersController : Controller
    {
        private readonly WorkerContext _context;

        public WorkersController(WorkerContext context)
        {
            _context = context;
        }

        // GET: Workers
        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Workers.ToListAsync());
        }

        // GET: Summary
        [AllowAnonymous]
        public async Task<IActionResult> Summary()
        {
            return View(await _context.Workers.ToListAsync());
        }

        // GET: Workers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pieceworkerModel = await _context.Workers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pieceworkerModel == null)
            {
                return NotFound();
            }

            return View(pieceworkerModel);
        }

        // GET: Workers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Workers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Messages,IsSenior")] PieceworkerModel pieceworkerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pieceworkerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pieceworkerModel);
        }

        // GET: Workers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pieceworkerModel = await _context.Workers.FindAsync(id);
            if (pieceworkerModel == null)
            {
                return NotFound();
            }
            return View(pieceworkerModel);
        }

        // POST: Workers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Messages,IsSenior")] PieceworkerModel pieceworkerModel)
        {
            if (id != pieceworkerModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pieceworkerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PieceworkerModelExists(pieceworkerModel.Id))
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
            return View(pieceworkerModel);
        }

        // GET: Workers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pieceworkerModel = await _context.Workers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pieceworkerModel == null)
            {
                return NotFound();
            }

            return View(pieceworkerModel);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pieceworkerModel = await _context.Workers.FindAsync(id);
            _context.Workers.Remove(pieceworkerModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PieceworkerModelExists(int id)
        {
            return _context.Workers.Any(e => e.Id == id);
        }
    }
}
