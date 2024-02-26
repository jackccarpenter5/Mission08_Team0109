using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Mission08_Team0109.Models;

namespace Mission08_Team0109.Controllers
{
    public class HomeController : Controller
    {
        private JobContext _context;
        public HomeController(JobContext temp)
        {
            _context = temp;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult EnterAJob()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EnterAJob(Job response)
        {
            _context.Jobs.Add(response);
            _context.SaveChanges();

            return View("Confirmation", response);
        }

        public IActionResult JobList()
        {
            var jobs = _context.Jobs
                .OrderBy(x => x.Quadrant)
                .ToList();

            return View(jobs);
        }

    }
}
