using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entities
{
    public class Resource : BaseEntity
    {
        
        public string Name { get; set; }

        public int PlaceId { get; set; }
        public Place Place { get; set; }

        public int? Capacity { get; set; }

        // Navigation
        public ICollection<TimeSlot> TimeSlots { get; set; }

    }
}
