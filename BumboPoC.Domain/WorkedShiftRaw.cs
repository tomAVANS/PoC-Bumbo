using System;

namespace BumboPoC.Domain
{
	public class WorkedShiftRaw
	{
		public int EmployeeId { get; set; }
		
		public string EmployeeFirstName { get; set; }
		
		public string EmployeeMiddleName { get; set; }
		
		public string EmployeeLastName { get; set; }
		
		public string EmployeeIban { get; set; }
		
		public string EmployeeEmail { get; set; }
		
		public DateTimeOffset EmployeeDateOfBirth { get; set; }
		
		public string EmployeeNfcCardId { get; set; }
		
		public int TimeBlockId { get; set; }
		
		public int TimeBlockEmployeeId { get; set; }
		
		public int TimeBlockTimeScheduleId { get; set; }
		
		public DateTimeOffset TimeBlockStartTime { get; set; }
		
		public DateTimeOffset TimeBlockEndTime { get; set; }
		
		public int TimeEntryId { get; set; }
		
		public int TimeEntryEmployeeId { get; set; }
		
		public DateTimeOffset TimeEntryStartDateTime { get; set; }
		
		public DateTimeOffset TimeEntryEndDateTime { get; set; }
		
		public ApproveStatus TimeApproveStatus { get; set; }
	}
}