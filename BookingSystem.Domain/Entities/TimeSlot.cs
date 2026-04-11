using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entities
{
    public class TimeSlot : BaseEntity
    {
        public int ResourceId { get; set; }
        public Resource Resource { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public bool IsAvailable { get; set; } = true;

        // Navigation
        public Booking Booking { get; set; }

    }
}
