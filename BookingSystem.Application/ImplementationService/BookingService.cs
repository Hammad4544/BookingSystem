using BookingSystem.Application.InterfaceService;
using BookingSystem.Domain.Entities;
using BookingSystem.Domain.Enums;
using BookingSystem.Domain.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.ImplementationService
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingService(IUnitOfWork unitOfWork ) {
        
            _unitOfWork = unitOfWork;
        }

        public async Task CancelBookingAsync(int bookingId, string userId)
        {
            var booking = await _unitOfWork.Bookings.GetByIdAsync(bookingId);
            if(booking == null)
                throw new Exception("Booking not found");
            if(booking.UserId != userId)
                throw new Exception("Unauthorized to cancel this booking");
            if(booking.Status == BookingStatus.Cancelled)
                throw new Exception("Already cancelled");
            var solt = await _unitOfWork.TimeSlots.GetByIdWithBookingAsync(booking.TimeSlotId);
            booking.Status = BookingStatus.Cancelled;
            solt.IsAvailable = true;
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task CreateBookingAsync(string userId, int timeSlotId)
        {
            var slot = await _unitOfWork.TimeSlots
    .GetByIdWithBookingAsync(timeSlotId);

            if (slot == null)
                throw new Exception("TimeSlot not found");

            if (!slot.IsAvailable)
                throw new Exception("Slot not available");

            if (slot.Booking != null)
                throw new Exception("Slot already booked");

            if (slot.StartTime <= DateTime.UtcNow)
                throw new Exception("Cannot book past slot");

            var booking = new Booking
            {
                UserId = userId,
                ResourceId = slot.ResourceId,
                TimeSlotId = slot.Id,
                Status = BookingStatus.Pending,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddMinutes(15)
            };

            slot.IsAvailable = false;

            await _unitOfWork.Bookings.AddAsync(booking);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<TimeSlot>> GetAvailableSlots(int resourceId)
        {
           return await _unitOfWork.TimeSlots.GetAvailableSlotsByResourceIdAsync(resourceId);
        }
    }
}
