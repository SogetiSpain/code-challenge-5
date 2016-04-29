using CrossCutting.Models;
using System.Collections.Generic;

namespace Amaia_ReservaTrenes.ReservationHandler
{
    public abstract class Handler
    {
        protected Handler successor;

        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }

        public abstract void HandleReservationRequest(Dictionary<string, SeatProperty> seats, TrainReservation reservation);
    }
}
