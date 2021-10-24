using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BumboPoC.Domain;
using BumboPoC.Domain.Extensions;
using BumboPoC.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BumboPoC.Web.Controllers
{
    public class RegisteredTimeController : Controller
    {
        private readonly BumboContext _bumboContext;
        private readonly ITimeEntryRepository repo;

        public RegisteredTimeController(BumboContext bumboContext)
        {
            _bumboContext = bumboContext;
            repo = new TimeEntryRepositorySql(_bumboContext);

        }
        
        public IActionResult Index()
        {
            var workedShifts = _bumboContext.USP_GetWorkedShifts();
            return View(workedShifts);
        }
        
        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var timeEntry = _bumboContext.TimeEntries.Find(id);
                return View(timeEntry);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(int id, TimeEntry timeEntry)
        {
            if (id != timeEntry.Id)
            {
                return NotFound();
            }
            // if (ModelState.IsValid)
            // 
            var model = repo.Update(timeEntry);
                return RedirectToAction("Index");
            //}
            return View(timeEntry);
        }

        public IActionResult Delete(int? id)
        {
            var timeEntry = _bumboContext.TimeEntries.Find(id);
            return View(timeEntry);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }
        
        public IActionResult Verify(int id)
        {
            var timeEntry = _bumboContext.TimeEntries.Find(id);
            timeEntry.ApproveStatus = ApproveStatus.Approved;
            _bumboContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}