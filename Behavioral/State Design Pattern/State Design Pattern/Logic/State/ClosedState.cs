using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State_Design_Pattern.Logic.State
{
    public class ClosedState : BookingState
    {
        private string reasonClosed;
        public ClosedState(string reason)
        {
            reasonClosed = reason;
        }
        public override void Cancel(BookingContext context)
        {
            context.View.ShowError("Invalid context for this state", "Closed booking error");
        }

        public override void DatePassed(BookingContext context)
        {
            context.View.ShowError("Invalid context for this state", "Closed booking error");
        }

        public override void EnterDetails(BookingContext context, string attendee, int ticketCount)
        {
            context.View.ShowError("Invalid context for this state", "Closed booking error");
        }

        public override void EnterState(BookingContext context)
        {
            context.ShowState("Closed");
            context.View.ShowStatusPage(reasonClosed);
        }
    }
}
