using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BumboPoC.Domain;
using BumboPoC.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BumboPoC.Web.Controllers
{
    public class RegisteredTimeController : Controller
    {
        private readonly BumboContext _bumboContext;

        public RegisteredTimeController(BumboContext bumboContext)
        {
            _bumboContext = bumboContext;
        }
        
        public IActionResult Index()
        {
            var registeredTimeViewModel = _bumboContext.Employees
                .Join(
                        _bumboContext.TimeEntries,
                        employee => employee.Id,
                        timeEntry => timeEntry.EmployeeId,
                        (employee, timeEntry) => new RegisteredTimeViewModel()
                        {
                            Employee = employee,
                            TimeEntry = timeEntry
                        }).ToList();
                return View(registeredTimeViewModel);
        }
    }
}