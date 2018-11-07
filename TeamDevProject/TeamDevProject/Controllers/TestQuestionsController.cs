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
    public class TestQuestionsController : Controller
    {
        private readonly TeamDevProjectContext _context;

        public TestQuestionsController(TeamDevProjectContext context)
        {
            _context = context;
        }

        // GET: TestQuestions
        public async Task<IActionResult> Index()
        {
            var teamDevProjectContext = _context.TestQuestions.Include(t => t.Test);
            return View(await teamDevProjectContext.ToListAsync());
        }

        // GET: TestQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testQuestions = await _context.TestQuestions
                .Include(t => t.Test)
                .FirstOrDefaultAsync(m => m.QuestionId == id);
            if (testQuestions == null)
            {
                return NotFound();
            }

            return View(testQuestions);
        }

        // GET: TestQuestions/Create
        public IActionResult Create()
        {
            ViewData["TestId"] = new SelectList(_context.Test, "TestId", "TestId");
            return View();
        }

        // POST: TestQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TestId,QuestionId,Answer1,Answer2,Answer3,Answer4,CorrectAnswer,Question")] TestQuestions testQuestions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testQuestions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TestId"] = new SelectList(_context.Test, "TestId", "TestId", testQuestions.TestId);
            return View(testQuestions);
        }

        // GET: TestQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testQuestions = await _context.TestQuestions.FindAsync(id);
            if (testQuestions == null)
            {
                return NotFound();
            }
            ViewData["TestId"] = new SelectList(_context.Test, "TestId", "TestId", testQuestions.TestId);
            return View(testQuestions);
        }

        // POST: TestQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TestId,QuestionId,Answer1,Answer2,Answer3,Answer4,CorrectAnswer,Question")] TestQuestions testQuestions)
        {
            if (id != testQuestions.QuestionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testQuestions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestQuestionsExists(testQuestions.QuestionId))
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
            ViewData["TestId"] = new SelectList(_context.Test, "TestId", "TestId", testQuestions.TestId);
            return View(testQuestions);
        }

        // GET: TestQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testQuestions = await _context.TestQuestions
                .Include(t => t.Test)
                .FirstOrDefaultAsync(m => m.QuestionId == id);
            if (testQuestions == null)
            {
                return NotFound();
            }

            return View(testQuestions);
        }

        // POST: TestQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testQuestions = await _context.TestQuestions.FindAsync(id);
            _context.TestQuestions.Remove(testQuestions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestQuestionsExists(int id)
        {
            return _context.TestQuestions.Any(e => e.QuestionId == id);
        }
    }
}
