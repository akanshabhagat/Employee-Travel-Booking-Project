using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVC_TravelBooking_Project.Models
{
    public partial class Emp_Travel_BookingContext : DbContext
    {
        public Emp_Travel_BookingContext()
        {
        }

        public Emp_Travel_BookingContext(DbContextOptions<Emp_Travel_BookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<TravelRequest> TravelRequests { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost; database=Emp_Travel_Booking; Trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__262359AB65A908B1");

                entity.ToTable("Employee");

                entity.Property(e => e.EmpId).HasColumnName("Emp_Id");

                entity.Property(e => e.EmpAddress)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Emp_Address");

                entity.Property(e => e.EmpContact)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Emp_Contact");

                entity.Property(e => e.EmpDob)
                    .HasColumnType("date")
                    .HasColumnName("Emp_DOB");

                entity.Property(e => e.EmpFirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Emp_FirstName");

                entity.Property(e => e.EmpLastName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Emp_LastName");
            });

            modelBuilder.Entity<TravelRequest>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK__Travel_R__E9C5B373C7C84DA3");

                entity.ToTable("Travel_Request");

                entity.Property(e => e.RequestId).HasColumnName("Request_Id");

                entity.Property(e => e.ApprovalStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Approval_Status");

                entity.Property(e => e.BookingStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Booking_Status");

                entity.Property(e => e.CurrentStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Current_Status");

                entity.Property(e => e.EmpId).HasColumnName("Emp_Id");

                entity.Property(e => e.LocFrom)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Loc_From");

                entity.Property(e => e.LocTo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Loc_To");

                entity.Property(e => e.ReqDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Req_Date");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TravelRequests)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__Travel_Re__Emp_I__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
