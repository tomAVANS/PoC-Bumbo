namespace BumboPoC.Domain
{
	public class WorkedShift
	{
		public Employee Employee { get; set; }
		
		public TimeBlock TimeBlock { get; set; }
		
		public TimeEntry TimeEntry { get; set; }
	}
}