using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BumboPoC.Domain
{
	public class TimeSchedule
	{
		[Key]
		public int Id { get; set; }
		
		public int WeekNumber { get; set; }
		
		public int Year { get; set; }
		
		public ICollection<TimeBlock> TimeBlocks { get; set; }
		
	}
}