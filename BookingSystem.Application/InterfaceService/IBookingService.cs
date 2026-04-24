using BookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.InterfaceService
{
    public interface IBookingService
    {
        Task CreateBookingAsync(string userId, int timeSlotId);
        public  Task<List<TimeSlot>> GetAvailableSlots(int resourceId);
        public Task CancelBookingAsync(int bookingId, string userId);

        //Task<BookingDto> GetBookingByIdAsync(Guid bookingId);
        //Task<IEnumerable<BookingDto>> GetAllBookingsAsync();
        //Task UpdateBookingAsync(BookingDto bookingDto);
        //Task DeleteBookingAsync(Guid bookingId);
    }
}
