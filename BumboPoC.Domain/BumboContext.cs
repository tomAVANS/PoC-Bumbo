using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BumboPoC.Domain
{
	public class BumboContext : DbContext
	{

		public BumboContext(DbContextOptions<BumboContext> options) : base(options)
		{
			
		}
		
		public DbSet<Employee> Employees { get; set; }
		public DbSet<TimeEntry> TimeEntries { get; set; }
		public DbSet<NfcCard> NfcCards { get; set; }
		public DbSet<TimeBlock> TimeBlocks { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Employee>().HasMany(e => e.TimeEntries).WithOne(te => te.Employee).OnDelete(DeleteBehavior.Cascade);
			modelBuilder.Entity<TimeSchedule>().HasMany(t => t.TimeBlocks).WithOne(t => t.TimeSchedule).OnDelete(DeleteBehavior.Cascade);
			modelBuilder.Entity<TimeBlock>().HasOne(t => t.Employee).WithMany(e => e.TimeBlocks);
			
			
			modelBuilder.Entity<NfcCard>().HasData(new List<NfcCard>()
			{
				new NfcCard()
				{
					Id = "933762014625"
				},
				new NfcCard()
				{
					Id = "1047276881072"
				}
			});

			modelBuilder.Entity<Employee>().HasData(new List<Employee>()
			{
				new Employee()
				{
					Id = 1,
					FirstName = "Tom",
					LastName = "Coldenhoff",
					Email = "t.coldenhoff@student.avans.nl",
					DateOfBirth = new DateTimeOffset(2000, 7, 9, 0, 0, 0,
						TimeSpan.FromHours(DateTime.Now.Hour - DateTime.UtcNow.Hour)),
					PhoneNumber = "+0612345678",
					NfcCardId = "933762014625"
				},
				new Employee()
				{
					Id = 2,
					FirstName = "John",
					LastName = "Doe",
					Email = "j.doe@student.avans.nl",
					DateOfBirth = new DateTimeOffset(1987, 7, 9, 0, 0, 0,
						TimeSpan.FromHours(DateTime.Now.Hour - DateTime.UtcNow.Hour)),
					PhoneNumber = "+0612345678",
					NfcCardId = "1047276881072"
				},
			});

			modelBuilder.Entity<TimeSchedule>().HasData(new List<TimeSchedule>()
			{
				new TimeSchedule()
				{
					Id = 1,
					WeekNumber = 42,
					Year = 2021
				}
			});

			modelBuilder.Entity<TimeBlock>().HasData(new List<TimeBlock>()
			{
				new TimeBlock()
				{
					Id = 1,
					StartTime = new DateTimeOffset(2021, 10, 18, 16, 00, 00, new TimeSpan(2, 0, 0)),
					EndTime = new DateTimeOffset(2021, 10, 18, 21, 00, 00, new TimeSpan(2, 0, 0)),
					EmployeeId = 1,
					TimeScheduleId = 1
				},
				new TimeBlock()
				{
					Id = 2,
					StartTime = new DateTimeOffset(2021, 10, 19, 7, 00, 00, new TimeSpan(2, 0, 0)),
					EndTime = new DateTimeOffset(2021, 10, 19, 12, 00, 00, new TimeSpan(2, 0, 0)),
					EmployeeId = 1,
					TimeScheduleId = 1
				},
				new TimeBlock()
				{
					Id = 3,
					StartTime = new DateTimeOffset(2021, 10, 21, 18, 00, 00, new TimeSpan(2, 0, 0)),
					EndTime = new DateTimeOffset(2021, 10, 21, 21, 00, 00, new TimeSpan(2, 0, 0)),
					EmployeeId = 1,
					TimeScheduleId = 1
				},
				new TimeBlock()
				{
					Id = 4,
					StartTime = new DateTimeOffset(2021, 10, 18, 7, 00, 00, new TimeSpan(2, 0, 0)),
					EndTime = new DateTimeOffset(2021, 10, 18, 17, 00, 00, new TimeSpan(2, 0, 0)),
					EmployeeId = 2,
					TimeScheduleId = 1
				},
				new TimeBlock()
				{
					Id = 5,
					StartTime = new DateTimeOffset(2021, 10, 19, 12, 00, 00, new TimeSpan(2, 0, 0)),
					EndTime = new DateTimeOffset(2021, 10, 19, 21, 00, 00, new TimeSpan(2, 0, 0)),
					EmployeeId = 2,
					TimeScheduleId = 1
				},
				new TimeBlock()
				{
					Id = 6,
					StartTime = new DateTimeOffset(2021, 10, 20, 14, 00, 00, new TimeSpan(2, 0, 0)),
					EndTime = new DateTimeOffset(2021, 10, 20, 21, 00, 00, new TimeSpan(2, 0, 0)),
					EmployeeId = 2,
					TimeScheduleId = 1
				},
			});
			

			modelBuilder.Entity<TimeEntry>().HasIndex(t => t.EmployeeId);
			modelBuilder.Entity<TimeEntry>().HasData(new List<TimeEntry>()
			{
				new TimeEntry()
				{
					Id = 1,
					EmployeeId = 1,
					StartDateTime = new DateTimeOffset(2021, 10, 18, 16, 30, 00,
						new TimeSpan(2, 0, 0)),
					EndDateTime = new DateTimeOffset(2021, 10, 18, 21, 30, 00,
						new TimeSpan(2, 0, 0)),
				},
				new TimeEntry()
				{
					Id = 2,
					EmployeeId = 1,
					StartDateTime = new DateTimeOffset(2021, 10, 19, 6, 56, 00,
						new TimeSpan(2, 0, 0)),
					EndDateTime = new DateTimeOffset(2021, 10, 19, 12, 2, 00,
						new TimeSpan(2, 0, 0)),
				},
				new TimeEntry()
				{
					Id = 3,
					EmployeeId = 2,
					StartDateTime = new DateTimeOffset(2021, 10, 21, 18, 01, 00,
						new TimeSpan(2, 0, 0)),
					EndDateTime = new DateTimeOffset(2021, 10, 21, 21, 15, 00,
						new TimeSpan(2, 0, 0)),
				},
				new TimeEntry()
				{
					Id = 4,
					EmployeeId = 2,
					StartDateTime = new DateTimeOffset(2021, 10, 18, 7, 00, 00,
						new TimeSpan(2, 0, 0)),
					EndDateTime = new DateTimeOffset(2021, 10, 18, 17, 45, 00,
						new TimeSpan(2, 0, 0)),
				},
				new TimeEntry()
				{
					Id = 5,
					EmployeeId = 2,
					StartDateTime = new DateTimeOffset(2021, 10, 19, 11, 45, 00,
						new TimeSpan(2, 0, 0)),
					EndDateTime = new DateTimeOffset(2021, 10, 19, 21, 8, 00,
						new TimeSpan(2, 0, 0)),
				},
				new TimeEntry()
				{
					Id = 6,
					EmployeeId = 2,
					StartDateTime = new DateTimeOffset(2021, 10, 20, 14, 00, 00,
						new TimeSpan(2, 0, 0)),
				},
			});
		}
	}
}