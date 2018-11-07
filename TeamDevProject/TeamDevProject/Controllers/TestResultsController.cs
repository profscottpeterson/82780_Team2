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
    public class TestResultsController : Controller
    {
        private readonly TeamDevProjectContext _context;

        public TestResultsController(TeamDevProjectContext context)
        {
            _context = context;
        }

        // GET: TestResults
        public async Task<IActionResult> Index()
        {
            var teamDevProjectContext = _context.TestResults.Include(t => t.Student);
            return View(await teamDevProjectContext.ToListAsync());
        }

        // GET: TestResults/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testResults = await _context.TestResults
                .Include(t => t.Student)
                .FirstOrDefaultAsync(m => m.TestResId == id);
            if (testResults == null)
            {
                return NotFound();
            }

            return View(testResults);
        }

        // GET: TestResults/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Student, "StudId", "StudId");
            return View();
        }

        // POST: TestResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TestResId,TestId,Score,Answers,StudentId")] TestResults testResults)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testResults);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "StudId", "StudId", testResults.StudentId);
            return View(testResults);
        }

        // GET: TestResults/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testResults = await _context.TestResults.FindAsync(id);
            if (testResults == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "StudId", "StudId", testResults.StudentId);
            return View(testResults);
        }

        // POST: TestResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TestResId,TestId,Score,Answers,StudentId")] TestResults testResults)
        {
            if (id != testResults.TestResId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testResults);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestResultsExists(testResults.TestResId))
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
            ViewData["StudentId"] = new SelectList(_context.Student, "StudId", "StudId", testResults.StudentId);
            return View(testResults);
        }

        // GET: TestResults/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testResults = await _context.TestResults
                .Include(t => t.Student)
                .FirstOrDefaultAsync(m => m.TestResId == id);
            if (testResults == null)
            {
                return NotFound();
            }

            return View(testResults);
        }

        // POST: TestResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testResults = await _context.TestResults.FindAsync(id);
            _context.TestResults.Remove(testResults);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestResultsExists(int id)
        {
            return _context.TestResults.Any(e => e.TestResId == id);
        }
    }
}
