using System;
using System.Linq;
using BumboPoC.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BumboPoC.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TimeEntryController : ControllerBase
	{
		private readonly BumboContext _bumboContext;

		private readonly ILogger<TimeEntryController> _logger;
		
		public TimeEntryController(BumboContext bumboContext, ILogger<TimeEntryController> logger)
		{
			_bumboContext = bumboContext;
			_logger = logger;
		}

		[HttpGet]
		[Route("test")]
		public IActionResult lol()
		{
			return Ok("wtf");
		}

		[HttpPost]
		[Route("add")]
		public IActionResult AddEntry([FromBody]NfcCard card)
		{
			var userBelongingToCard =
				_bumboContext.Employees.Where(u => u.NfcCardId == card.Id).Include(u => u.TimeEntries).FirstOrDefault();

			if (userBelongingToCard == null)
			{
				return BadRequest();
			}
			
			_logger.LogInformation($"Received time entry from {userBelongingToCard.FirstName} {userBelongingToCard.MiddleName} {userBelongingToCard.LastName}");

			var mostRecentEntry = userBelongingToCard.TimeEntries.OrderByDescending(t => t.StartDateTime)
				.FirstOrDefault();
			
			if (mostRecentEntry?.EndDateTime == DateTimeOffset.MinValue)
			{
				mostRecentEntry.EndDateTime = DateTimeOffset.Now;
				_bumboContext.SaveChanges();
				return Ok(mostRecentEntry);
			}
			else
			{
				var timeEntry = new TimeEntry()
				{
					StartDateTime = DateTimeOffset.Now
				};
				
				userBelongingToCard.TimeEntries.Add(timeEntry);
				_bumboContext.SaveChanges();
				return Created("", timeEntry); //TODO Add uri for getting
			}
		}
	}
}