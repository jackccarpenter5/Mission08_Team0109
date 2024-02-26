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

        // Drew will add the edit and delete functions

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Jobs.Single(x => x.JobId == id);
            return View(recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Job updated)
        {
            _context.Update(updated);
            _context.SaveChanges();

            return RedirectToAction("JobList");
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            var recordToDelete = _context.Jobs.Single(x => x.JobId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Job deleted)
        {
            _context.Jobs.Remove(deleted);
            _context.SaveChanges();

            return RedirectToAction("JobList");
        }

    }
}
