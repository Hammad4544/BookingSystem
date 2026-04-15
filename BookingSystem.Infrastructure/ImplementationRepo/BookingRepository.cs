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
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context) {
        
        

            _context = context;
        }
        public async Task AddAsync(Booking booking)
        {
           await _context.Bookings.AddAsync(booking);
        }

        public async Task<Booking?> GetByIdAsync(int id)
        {
            var res = await _context.Bookings.FirstOrDefaultAsync(b=>b.Id==id);
            return res;
        }
    }
}
