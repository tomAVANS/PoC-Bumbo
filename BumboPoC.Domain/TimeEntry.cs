using System;
using System.ComponentModel.DataAnnotations;

namespace BumboPoC.Domain
{
	public class TimeEntry
	{
		[Key]
		public int Id { get; set; }
		
		public int EmployeeId { get; set; }
		
		[Required]
		public Employee Employee { get; set; }
		
		[Required]
		public DateTimeOffset StartDateTime { get; set; }
		
		public DateTimeOffset EndDateTime { get; set; }

		[Required]
		public ApproveStatus ApproveStatus { get; set; }
	}
}