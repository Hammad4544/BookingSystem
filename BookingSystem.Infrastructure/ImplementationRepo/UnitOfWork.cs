using BookingSystem.Domain.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.ImplementationRepo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBookingRepository Bookings { get; private set; }
        public ITimeSlotRepository TimeSlots { get; private set; }
        public UnitOfWork(ApplicationDbContext context, IBookingRepository bookingRepository, ITimeSlotRepository timeSlotRepository)
        {
            _context = context;
            Bookings = bookingRepository;
            TimeSlots = timeSlotRepository;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
