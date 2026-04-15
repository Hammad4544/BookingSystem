using BookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.InterfaceRepo
{
    public interface ITimeSlotRepository
    {
        Task<TimeSlot?> GetByIdWithBookingAsync(int id);
        Task UpdateAsync(TimeSlot timeSlot);
    }
}
