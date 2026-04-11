using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        // Navigation
        public ICollection<Booking> Bookings { get; set; }
    }
}
