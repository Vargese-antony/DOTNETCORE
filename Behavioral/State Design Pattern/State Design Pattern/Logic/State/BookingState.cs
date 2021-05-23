using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State_Design_Pattern.Logic.State
{
    public abstract class BookingState
    {
        public abstract void EnterState(BookingContext context);
        public abstract void Cancel(BookingContext context);
        public abstract void DatePassed(BookingContext context);
        public abstract void EnterDetails(BookingContext context, string attendee, int ticketCount);
    }
}
