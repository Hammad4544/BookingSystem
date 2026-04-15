using BookingSystem.Domain.Entities;
using BookingSystem.Domain.InterfaceRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.ImplementationRepo
{
    public class TimeSlotRepository : ITimeSlotRepository
    {
        private readonly ApplicationDbContext _context;

        public TimeSlotRepository(ApplicationDbContext context ) {

            _context = context;
        }
        public async Task<TimeSlot?> GetByIdWithBookingAsync(int id)
        {
            var res = await _context.TimeSlots.Include(t=>t.Booking).FirstOrDefaultAsync(t=>t.Id==id);
            return res;
        }

        public async Task UpdateAsync(TimeSlot timeSlot)
        {
           _context.TimeSlots.Update(timeSlot);
        }
    }
}
