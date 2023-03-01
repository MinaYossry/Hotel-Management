using DatabaseContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContext.Configuration
{
    public class ReservationConfiguation : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.BirthDay)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.Gender)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.EmailAddress)
                .IsRequired();

            builder.Property(e => e.NumberGuest)
                .IsRequired();

            builder.Property(e => e.StreetAddress)
                .IsRequired();

            builder.Property(e => e.AptSuite)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.City)
                .IsRequired();

            builder.Property(e => e.State)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.ZipCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.RoomType)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.RoomFloor)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.RoomNumber)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.TotalBill)
                .IsRequired();

            builder.Property(e => e.PaymentType)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.CardType)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.CardNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.CardExp)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.CardCvc)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.ArrivalTime)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.LeavingTime)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.CheckIn)
                .IsRequired();

            builder.Property(e => e.BreakFast)
                .IsRequired();

            builder.Property(e => e.Lunch)
                .IsRequired();

            builder.Property(e => e.Dinner)
                .IsRequired();

            builder.Property(e => e.Cleaning)
                .IsRequired();

            builder.Property(e => e.Towel)
                .IsRequired();

            builder.Property(e => e.SSurprise)
                .IsRequired();

            builder.Property(e => e.SupplyStatus)
                .IsRequired();

            builder.Property(e => e.FoodBill)
                .IsRequired();
        }
    }
}
