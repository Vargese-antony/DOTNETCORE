using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State_Design_Pattern.Logic.State
{
    public class NewState : BookingState
    {
        public override void Cancel(BookingContext context)
        {
            context.TransitionToState(new ClosedState("Booking Cancelled"));
        }

        public override void DatePassed(BookingContext context)
        {
            context.TransitionToState(new ClosedState("Booking Expired"));
        }

        public override void EnterDetails(BookingContext context, string attendee, int ticketCount)
        {
            context.Attendee = attendee;
            context.TicketCount = ticketCount;
            context.TransitionToState(new PendingState());
        }

        public override void EnterState(BookingContext context)
        {
            context.BookingID = new Random().Next();
            context.ShowState("New");
            context.View.ShowEntryPage();
        }
    }
}
