using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BumboPoC.Domain
{
	public class TimeBlock
	{
		[Key]
		public int Id { get; set; }
		
		public DateTimeOffset StartTime { get; set; }

		public DateTimeOffset EndTime { get; set; }

		public int TimeScheduleId { get; set; }
		
		[ForeignKey(nameof(TimeScheduleId))]
		public TimeSchedule TimeSchedule { get; set; }

		public int EmployeeId { get; set; }
		
		[ForeignKey(nameof(EmployeeId))]
		public Employee Employee { get; set; }
	}
}