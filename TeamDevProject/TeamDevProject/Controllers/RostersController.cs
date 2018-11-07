using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeamDevProject.Models;

namespace TeamDevProject.Controllers
{
    public class RostersController : Controller
    {
        private readonly TeamDevProjectContext _context;

        public RostersController(TeamDevProjectContext context)
        {
            _context = context;
        }

        // GET: Rosters
        public async Task<IActionResult> Index()
        {
            var teamDevProjectContext = _context.Roster.Include(r => r.Course).Include(r => r.Stud);
            return View(await teamDevProjectContext.ToListAsync());
        }

        // GET: Rosters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roster = await _context.Roster
                .Include(r => r.Course)
                .Include(r => r.Stud)
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (roster == null)
            {
                return NotFound();
            }

            return View(roster);
        }

        // GET: Rosters/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId");
            ViewData["StudId"] = new SelectList(_context.Student, "StudId", "StudId");
            return View();
        }

        // POST: Rosters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,StudId")] Roster roster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", roster.CourseId);
            ViewData["StudId"] = new SelectList(_context.Student, "StudId", "StudId", roster.StudId);
            return View(roster);
        }

        // GET: Rosters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roster = await _context.Roster.FindAsync(id);
            if (roster == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", roster.CourseId);
            ViewData["StudId"] = new SelectList(_context.Student, "StudId", "StudId", roster.StudId);
            return View(roster);
        }

        // POST: Rosters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,StudId")] Roster roster)
        {
            if (id != roster.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RosterExists(roster.CourseId))
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
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", roster.CourseId);
            ViewData["StudId"] = new SelectList(_context.Student, "StudId", "StudId", roster.StudId);
            return View(roster);
        }

        // GET: Rosters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roster = await _context.Roster
                .Include(r => r.Course)
                .Include(r => r.Stud)
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (roster == null)
            {
                return NotFound();
            }

            return View(roster);
        }

        // POST: Rosters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roster = await _context.Roster.FindAsync(id);
            _context.Roster.Remove(roster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RosterExists(int id)
        {
            return _context.Roster.Any(e => e.CourseId == id);
        }
    }
}
