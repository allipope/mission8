using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mission8.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mission8.Controllers
{
    public class HomeController : Controller
    {
        private TaskApplicationContext taskContext { get; set; }

        // Constructor
        public HomeController(TaskApplicationContext x)
        {
            taskContext = x;
        }


        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public IActionResult TaskApplication()
        {
            ViewBag.Categories = taskContext.Categories.ToList();

            return View("TaskApplication", new ApplicationResponse());
        }

        [HttpPost]
        public IActionResult TaskApplication (ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                taskContext.Add(ar);
                taskContext.SaveChanges();
                return View("Index");
            }

            else
            {
                ViewBag.Categories = taskContext.Categories.ToList();
                return View();
            }
        }



        [HttpGet]
        public IActionResult Quadrants()
        {
            var tasks = taskContext.Responses
                .Include(x => x.Category)
                .ToList();
            return View(tasks);
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = taskContext.Categories.ToList();
            var submission = taskContext.Responses.Single(x => x.ApplicationID == id);
            return View("TaskApplication", submission);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationResponse ar)
        {
            taskContext.Update(ar);
            taskContext.SaveChanges();
            return RedirectToAction("Quadrants");
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var submission = taskContext.Responses.Single(x => x.ApplicationID == id);
            return View(submission);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            taskContext.Responses.Remove(ar);
            taskContext.SaveChanges();
            return RedirectToAction("Quadrants");
        }

    }
}