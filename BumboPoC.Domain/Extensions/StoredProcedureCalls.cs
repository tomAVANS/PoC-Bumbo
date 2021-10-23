using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BumboPoC.Domain.Extensions
{
	public static class StoredProcedureCalls
	{
		public static IEnumerable<WorkedShift> USP_GetWorkedShifts(this BumboContext context)
		{
			var workedShiftsRaw = context.WorkedShifts.FromSqlRaw("EXEC [dbo].[USP_GetWorkedShifts]").ToList();

			var workedShifts = workedShiftsRaw.Select(w => new WorkedShift()
			{
				Employee = new Employee()
				{
					Id = w.EmployeeId,
					FirstName = w.EmployeeFirstName,
					MiddleName = w.EmployeeMiddleName,
					LastName = w.EmployeeLastName,
					Iban = w.EmployeeIban,
					Email = w.EmployeeEmail,
					DateOfBirth = w.EmployeeDateOfBirth,
					NfcCardId = w.EmployeeNfcCardId,
				},
				TimeBlock = new TimeBlock()
				{
					Id = w.TimeBlockId,
					EmployeeId = w.TimeBlockEmployeeId,
					StartTime = w.TimeBlockStartTime,
					EndTime = w.TimeBlockEndTime,
					TimeScheduleId = w.TimeBlockTimeScheduleId
				},
				TimeEntry = new TimeEntry()
				{
					Id = w.TimeEntryId,
					EmployeeId = w.EmployeeId,
					StartDateTime = w.TimeEntryStartDateTime,
					EndDateTime = w.TimeEntryEndDateTime,
					ApproveStatus = w.TimeApproveStatus
				}
			});
			
			return workedShifts;
		}
	}
}