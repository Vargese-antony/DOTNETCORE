using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State_Design_Pattern.Logic.State
{
    public class BookedState : BookingState
    {
        public override void Cancel(BookingContext context)
        {
            context.TransitionToState(new ClosedState("Booking cancelled: Expect a refund"));
        }

        public override void DatePassed(BookingContext context)
        {
            context.TransitionToState(new ClosedState("We hope you enjoyed the event!"));
        }

        public override void EnterDetails(BookingContext context, string attendee, int ticketCount)
        {
            throw new NotImplementedException();
        }

        public override void EnterState(BookingContext context)
        {
            context.ShowState("Booked");
            context.View.ShowStatusPage("Enjoy the event");
        }
    }
}
