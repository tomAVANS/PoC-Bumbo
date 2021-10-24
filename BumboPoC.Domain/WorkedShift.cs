using System;

namespace BumboPoC.Domain
{
	public class WorkedShift
	{
		public Employee Employee { get; set; }
		
		public TimeBlock TimeBlock { get; set; }
		
		public TimeEntry TimeEntry { get; set; }

		public TimeSpan Difference => (TimeEntry.EndDateTime - TimeEntry.StartDateTime) -
		                              (TimeBlock.EndTime - TimeBlock.StartTime);
	}
}