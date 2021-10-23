using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BumboPoC.Domain
{
	public class Employee
	{
		public Employee()
		{
			TimeEntries = new List<TimeEntry>();
		}
		
		[Key]
		public int Id { get; set; }

		[Required]
		public string FirstName { get; set; }
		
		public string MiddleName { get; set; }
		
		[Required]
		public string LastName { get; set; }
		
		public string Iban { get; set; }
		
		[Required]
		public string Email { get; set; }
		
		[Required]
		public string PhoneNumber { get; set; }
		
		[Required]
		public DateTimeOffset DateOfBirth { get; set; }
		
		public string NfcCardId { get; set; }
		public NfcCard NfcCard { get; set; }
		
		public ICollection<TimeEntry> TimeEntries { get; set; }
		
		public ICollection<TimeBlock> TimeBlocks { get; set; }
	}
}