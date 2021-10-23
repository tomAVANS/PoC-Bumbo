﻿// <auto-generated />
using System;
using BumboPoC.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BumboPoC.Domain.Migrations
{
    [DbContext(typeof(BumboContext))]
    partial class BumboContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BumboPoC.Domain.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("DateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Iban")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NfcCardId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NfcCardId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTimeOffset(new DateTime(2000, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Email = "t.coldenhoff@student.avans.nl",
                            FirstName = "Tom",
                            LastName = "Coldenhoff",
                            NfcCardId = "933762014625",
                            PhoneNumber = "+0612345678"
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTimeOffset(new DateTime(1987, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Email = "j.doe@student.avans.nl",
                            FirstName = "John",
                            LastName = "Doe",
                            NfcCardId = "1047276881072",
                            PhoneNumber = "+0612345678"
                        });
                });

            modelBuilder.Entity("BumboPoC.Domain.NfcCard", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("NfcCards");

                    b.HasData(
                        new
                        {
                            Id = "933762014625"
                        },
                        new
                        {
                            Id = "1047276881072"
                        });
                });

            modelBuilder.Entity("BumboPoC.Domain.TimeBlock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("EndTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("StartTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("TimeScheduleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TimeScheduleId");

                    b.ToTable("TimeBlock");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmployeeId = 1,
                            EndTime = new DateTimeOffset(new DateTime(2021, 10, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            StartTime = new DateTimeOffset(new DateTime(2021, 10, 18, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            TimeScheduleId = 1
                        },
                        new
                        {
                            Id = 2,
                            EmployeeId = 1,
                            EndTime = new DateTimeOffset(new DateTime(2021, 10, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            StartTime = new DateTimeOffset(new DateTime(2021, 10, 19, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            TimeScheduleId = 1
                        },
                        new
                        {
                            Id = 3,
                            EmployeeId = 1,
                            EndTime = new DateTimeOffset(new DateTime(2021, 10, 21, 21, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            StartTime = new DateTimeOffset(new DateTime(2021, 10, 21, 18, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            TimeScheduleId = 1
                        },
                        new
                        {
                            Id = 4,
                            EmployeeId = 2,
                            EndTime = new DateTimeOffset(new DateTime(2021, 10, 18, 17, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            StartTime = new DateTimeOffset(new DateTime(2021, 10, 18, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            TimeScheduleId = 1
                        },
                        new
                        {
                            Id = 5,
                            EmployeeId = 2,
                            EndTime = new DateTimeOffset(new DateTime(2021, 10, 19, 21, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            StartTime = new DateTimeOffset(new DateTime(2021, 10, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            TimeScheduleId = 1
                        },
                        new
                        {
                            Id = 6,
                            EmployeeId = 2,
                            EndTime = new DateTimeOffset(new DateTime(2021, 10, 19, 21, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            StartTime = new DateTimeOffset(new DateTime(2021, 10, 19, 14, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            TimeScheduleId = 1
                        });
                });

            modelBuilder.Entity("BumboPoC.Domain.TimeEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApproveStatus")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("EndDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("StartDateTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("TimeEntries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApproveStatus = 0,
                            EmployeeId = 1,
                            EndDateTime = new DateTimeOffset(new DateTime(2021, 10, 18, 21, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            StartDateTime = new DateTimeOffset(new DateTime(2021, 10, 18, 16, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0))
                        },
                        new
                        {
                            Id = 2,
                            ApproveStatus = 0,
                            EmployeeId = 1,
                            EndDateTime = new DateTimeOffset(new DateTime(2021, 10, 19, 12, 2, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            StartDateTime = new DateTimeOffset(new DateTime(2021, 10, 19, 6, 56, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0))
                        },
                        new
                        {
                            Id = 3,
                            ApproveStatus = 0,
                            EmployeeId = 2,
                            EndDateTime = new DateTimeOffset(new DateTime(2021, 10, 21, 21, 15, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            StartDateTime = new DateTimeOffset(new DateTime(2021, 10, 21, 18, 1, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0))
                        },
                        new
                        {
                            Id = 4,
                            ApproveStatus = 0,
                            EmployeeId = 2,
                            EndDateTime = new DateTimeOffset(new DateTime(2021, 10, 18, 17, 45, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            StartDateTime = new DateTimeOffset(new DateTime(2021, 10, 18, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0))
                        },
                        new
                        {
                            Id = 5,
                            ApproveStatus = 0,
                            EmployeeId = 2,
                            EndDateTime = new DateTimeOffset(new DateTime(2021, 10, 19, 21, 8, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            StartDateTime = new DateTimeOffset(new DateTime(2021, 10, 19, 11, 45, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0))
                        },
                        new
                        {
                            Id = 6,
                            ApproveStatus = 0,
                            EmployeeId = 2,
                            EndDateTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            StartDateTime = new DateTimeOffset(new DateTime(2021, 10, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0))
                        });
                });

            modelBuilder.Entity("BumboPoC.Domain.TimeSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("WeekNumber")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TimeSchedule");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            WeekNumber = 42,
                            Year = 2021
                        });
                });

            modelBuilder.Entity("BumboPoC.Domain.Employee", b =>
                {
                    b.HasOne("BumboPoC.Domain.NfcCard", "NfcCard")
                        .WithMany()
                        .HasForeignKey("NfcCardId");

                    b.Navigation("NfcCard");
                });

            modelBuilder.Entity("BumboPoC.Domain.TimeBlock", b =>
                {
                    b.HasOne("BumboPoC.Domain.Employee", "Employee")
                        .WithMany("TimeBlocks")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BumboPoC.Domain.TimeSchedule", "TimeSchedule")
                        .WithMany("TimeBlocks")
                        .HasForeignKey("TimeScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("TimeSchedule");
                });

            modelBuilder.Entity("BumboPoC.Domain.TimeEntry", b =>
                {
                    b.HasOne("BumboPoC.Domain.Employee", "Employee")
                        .WithMany("TimeEntries")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("BumboPoC.Domain.Employee", b =>
                {
                    b.Navigation("TimeBlocks");

                    b.Navigation("TimeEntries");
                });

            modelBuilder.Entity("BumboPoC.Domain.TimeSchedule", b =>
                {
                    b.Navigation("TimeBlocks");
                });
#pragma warning restore 612, 618
        }
    }
}
