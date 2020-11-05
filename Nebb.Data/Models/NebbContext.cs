using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Nebb.Data.ViewModels;

namespace Nebb.Data.Models
{
    public partial class NebbContext : DbContext
    {
      

        //public NebbContext()
        //{
        //}

        public NebbContext(DbContextOptions<NebbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FlightInfo> FlightInfo { get; set; }
        public virtual DbSet<PassengerInfo> PassengerInfo { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<TicketAViewModel> TicketAViewModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost,1432;Initial Catalog=Nebb;Persist Security Info=True;User ID=sa;Password=!2E45678");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlightInfo>(entity =>
            {
                entity.Property(e => e.Departure).HasColumnType("datetime");

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Origin)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnDay).HasColumnType("datetime");
            });

            modelBuilder.Entity<PassengerInfo>(entity =>
            {
                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoyalMemberId)
                    .HasColumnName("LoyalMemberID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Passport)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.FlightId).HasColumnName("FlightID");

                entity.Property(e => e.PassengerId).HasColumnName("PassengerID");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.FlightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FlightInfo");

                entity.HasOne(d => d.Passenger)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.PassengerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PassengerInfo");
            });

            modelBuilder.Entity<TicketAViewModel>().HasData(
                new TicketAViewModel
                {
                    Id = 5,
                    FirstName = "Predrag",
                    LastName = "Nikolic",
                    DateOfBirth = new DateTime(1999, 01, 17),
                    Passport = "JKDAUYJDAKD",
                    Origin = "Skopje",
                    Destination = "Hawaii",
                    Departure = new DateTime(2020, 11, 17),
                    ReturnDay = new DateTime(2020, 12, 17),
                    FreeCarry = true,
                    CheckedIn = false,
                    TrolleyBag = false
                });
            

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
