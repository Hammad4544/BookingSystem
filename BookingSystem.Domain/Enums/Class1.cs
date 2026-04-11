using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Enums
{
    internal class Class1
    {
    }
    public enum PlaceType
    {
        Hotel,
        Clinic,
        Workspace
    }

    public enum BookingStatus
    {
        Pending,
        Confirmed,
        Cancelled
    }

    public enum PaymentStatus
    {
        Pending,
        Paid,
        Failed
    }
}
