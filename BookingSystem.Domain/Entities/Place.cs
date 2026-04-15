using BookingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entities
{
    public class Place : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public PlaceType Type { get; set; }

        public string OwnerId { get; set; }
        public User Owner { get; set; }

        // Navigation
        public ICollection<Resource> Resources { get; set; }
    }
}
