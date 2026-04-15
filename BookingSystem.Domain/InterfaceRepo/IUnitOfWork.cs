using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.InterfaceRepo
{
    public interface IUnitOfWork
    {
        IBookingRepository Bookings { get; }
        
        ITimeSlotRepository TimeSlots { get; }
        Task<int> SaveChangesAsync();
    }
}
