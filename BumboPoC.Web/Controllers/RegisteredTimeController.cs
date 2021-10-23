using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BumboPoC.Domain;
using BumboPoC.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            
            var employees = _bumboContext.Employees.Include(e => e.TimeBlocks).Include(e => e.TimeEntries).ToList();
            var registeredTimeViewModels = new List<RegisteredTimeViewModel>();
            foreach(var employee in employees)
            {
                foreach(var timeBlock in employee.TimeBlocks)
                {
                    var startTime = timeBlock.StartTime;
                    TimeEntry nearestTimeEntry = null;
                    foreach(var timeEntry in employee.TimeEntries.Where(t => t.StartDateTime.Date == startTime.Date))
                    {
                        if(nearestTimeEntry == null || timeBlock.StartTime-timeEntry.StartDateTime<timeBlock.StartTime- nearestTimeEntry.StartDateTime)
                        {
                            nearestTimeEntry = timeEntry;
                        }
                    }
                    registeredTimeViewModels.Add(new RegisteredTimeViewModel()
                    {
                        Employee = employee,
                        TimeBlock = timeBlock,
                        TimeEntry = nearestTimeEntry
                    });
                }
            }
            //var registeredTimeViewModel = _bumboContext.Employees
            //    .Join(
            //    _bumboContext.TimeEntries,
            //    employee => employee.Id,
            //    timeEntry => timeEntry.EmployeeId,
            //    (employee, timeEntry) => new
            //    {
            //        Employee = employee,
            //(        TimeEntry = timeEntry

            //    }
            //    ).Join(
            //    _bumboContext.TimeBlocks,
            //    employee => employee.Employee.Id,
            //    timeBlock => timeBlock.EmployeeId,
            //    (left, timeBlock) => new RegisteredTimeViewModel()
            //    {
            //        Employee = left.Employee,
            //        TimeBlock = timeBlock,
            //        TimeEntry = left.TimeEntry

            //    }
            //    ).Where(m => m.TimeEntry.StartDateTime.Day == m.TimeBlock.StartTime.Day).ToList();
            //    /*.Join
                //_bumboContext.TimeBlocks,
                //employee => employee.Id,
                //timeBlock => timeBlock.EmployeeId,
                //(employee, timeEntry,timeBlock) => new RegisteredTimeViewModel()
                //{
                //    Employee = employee,
                //    TimeEntry = timeEntry,
                //    TimeBlock = timeBlock
                //}
                //).ToList();*/
                return View(registeredTimeViewModels);
        }
    }
}