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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Employee>().HasMany(e => e.TimeEntries).WithOne(te => te.Employee).OnDelete(DeleteBehavior.Cascade);

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

			modelBuilder.Entity<TimeEntry>().HasIndex(t => t.EmployeeId);
			modelBuilder.Entity<TimeEntry>().HasData(new List<TimeEntry>()
			{
				new TimeEntry()
				{
					Id = 1,
					EmployeeId = 1,
					StartDateTime = new DateTimeOffset(2021, 10, 18, 16, 30, 00,
						TimeSpan.FromHours(DateTime.Now.Hour - DateTime.UtcNow.Hour)),
				},
				new TimeEntry()
				{
					Id = 2,
					EmployeeId = 2,
					StartDateTime = new DateTimeOffset(2021, 10, 18, 12, 30, 00,
						TimeSpan.FromHours(DateTime.Now.Hour - DateTime.UtcNow.Hour)),
					EndDateTime = new DateTimeOffset(2021, 10, 18, 18, 00, 00,
						TimeSpan.FromHours(DateTime.Now.Hour - DateTime.UtcNow.Hour)),
				},
			});
		}
	}
}