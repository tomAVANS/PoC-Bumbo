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

        public RegisteredTimeController(BumboContext bumboContext)
        {
            _bumboContext = bumboContext;
        }
        
        public IActionResult Index()

        {

            var workedShifts = _bumboContext.USP_GetWorkedShifts();
            return View(workedShifts);
        }
    }
}