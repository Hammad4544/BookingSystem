using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BookingSystem.Domain.Entities;

namespace BookingSystem.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Place> Places { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // هنظبط العلاقات تحت 👇
            builder.Entity<Booking>()
    .HasOne(b => b.User)
    .WithMany(u => u.Bookings)
    .HasForeignKey(b => b.UserId)
    .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<Place>()
    .HasOne(p => p.Owner)
    .WithMany()
    .HasForeignKey(p => p.OwnerId)
    .OnDelete(DeleteBehavior.Restrict);



            builder.Entity<Resource>()
    .HasOne(r => r.Place)
    .WithMany(p => p.Resources)
    .HasForeignKey(r => r.PlaceId);



            builder.Entity<TimeSlot>()
    .HasOne(t => t.Resource)
    .WithMany(r => r.TimeSlots)
    .HasForeignKey(t => t.ResourceId);


            builder.Entity<TimeSlot>()
    .HasOne(t => t.Booking)
    .WithOne(b => b.TimeSlot)
    .HasForeignKey<Booking>(b => b.TimeSlotId);

            builder.Entity<Payment>()
    .HasOne(p => p.Booking)
    .WithOne()
    .HasForeignKey<Payment>(p => p.BookingId);

            builder.Entity<TimeSlot>()
    .HasIndex(t => new { t.ResourceId, t.StartTime, t.EndTime })
    .IsUnique();
        }
    }
}
