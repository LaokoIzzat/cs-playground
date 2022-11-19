using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting
{
    public sealed class Restaurant
    {
        public string Name { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
        public IEnumerable<ClosurePeriod> ClosurePeriods { get; set; }
    }
}
