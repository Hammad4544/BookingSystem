using BookingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entities
{
    public class Booking : BaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int ResourceId { get; set; }
        public Resource Resource { get; set; }

        public int TimeSlotId { get; set; }
        public TimeSlot TimeSlot { get; set; }

        public BookingStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
