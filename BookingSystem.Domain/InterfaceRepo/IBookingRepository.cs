using BookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.InterfaceRepo
{
    public interface IBookingRepository
    {
        Task<Booking?> GetByIdAsync(int id);
        Task AddAsync(Booking booking);
    }
}
