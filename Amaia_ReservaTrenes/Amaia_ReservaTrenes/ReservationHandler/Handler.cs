namespace Amaia_ReservaTrenes.ReservationHandler
{
    using CrossCutting.Models;
    using System.Collections.Generic;
    using System.Net.Http;

    public abstract class Handler
    {
        protected Handler successor;

        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }

        public abstract void HandleReservationRequest(Dictionary<string, SeatProperty> seats, ReserveModel reservationReference, int numberSeats, HttpClient client);
    }
}
