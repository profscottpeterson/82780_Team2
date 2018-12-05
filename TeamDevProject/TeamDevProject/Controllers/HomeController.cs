using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeamDevProject.Models;

namespace TeamDevProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly TeamDevProjectContext _context;

        public HomeController(TeamDevProjectContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var teamDevProjectContext = _context.Test.Include(t => t.Course);
            return View(await teamDevProjectContext.ToListAsync());
        }

        public async Task<IActionResult> TakeTest(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questions = new List<TestQuestions>();

            foreach (var q in _context.TestQuestions)
            {
                if(q.TestId == id)
                {
                    questions.Add(q);
                }
            }

            if (questions == null)
            {
                return NotFound();
            }

            return View(questions);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Check(IFormCollection data)
        {
            int c = 0;
            int w = 0;

            double results;

            foreach (var question in data)
            {
                foreach (var q in _context.TestQuestions)
                {
                    if (q.QuestionId.ToString() == question.Key)
                    {
                        if(q.CorrectAnswer.ToString() == question.Value)
                        {
                            c++;
                            break;
                        } else
                        {
                            w++;
                            break;
                        }
                    }
                }
            }

            results = c / (c + w);

            return View(results);

        }
    }
}
