using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace State_Design_Pattern.Logic.State
{
    public class PendingState : BookingState
    {
        CancellationTokenSource cancellationToken;        
        public override void Cancel(BookingContext context)
        {
            cancellationToken.Cancel();
        }

        public override void DatePassed(BookingContext context)
        {
            throw new NotImplementedException();
        }

        public override void EnterDetails(BookingContext context, string attendee, int ticketCount)
        {
            throw new NotImplementedException();
        }

        public override void EnterState(BookingContext context)
        {
            cancellationToken = new CancellationTokenSource();

            context.ShowState("Pending");
            context.View.ShowStatusPage("Processing booking");

            StaticFunctions.ProcessBooking(context, ProcessingComplete, cancellationToken);
        }

        public void ProcessingComplete(BookingContext context, ProcessingResult result)
        {
            switch (result)
            {
                case ProcessingResult.Sucess:
                    context.TransitionToState(new BookedState());
                    break;
                case ProcessingResult.Fail:
                    context.View.ShowProcessingError();
                    context.TransitionToState(new NewState());
                    break;
                case ProcessingResult.Cancel:
                    context.TransitionToState(new ClosedState("Processing cancelled"));
                    break;
                default:
                    break;
            }
        }
    }
}
