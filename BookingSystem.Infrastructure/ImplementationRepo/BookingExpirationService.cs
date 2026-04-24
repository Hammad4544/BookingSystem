
using BookingSystem.Domain.Enums;
using BookingSystem.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.ImplementationService
{
    public class BookingExpirationService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public BookingExpirationService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _scopeFactory.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var expiredBookings = context.Bookings
                    .Where(b => b.Status == BookingStatus.Pending &&
                                b.ExpiresAt <= DateTime.UtcNow)
                    .ToList();

                foreach (var booking in expiredBookings)
                {
                    booking.Status = BookingStatus.Cancelled;

                    var slot = context.TimeSlots.FirstOrDefault(t => t.Id == booking.TimeSlotId);
                    if (slot != null)
                        slot.IsAvailable = true;
                }

                await context.SaveChangesAsync();

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
