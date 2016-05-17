namespace Amaia_ReservaTrenes.ReservationHandler
{
    using CrossCutting.Models;
    using System.Collections.Generic;
    using System.Net.Http;
    using TrainWebService;
    public abstract class Handler
    {
        protected Handler successor;

        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }

        //TODO Cuando se ctor de la clase (Service modelo se instance)

        public abstract void HandleReservationRequest(Dictionary<string, SeatProperty> trainInfo, ReserveModel reservationReference, int numberSeats, Service service);
    }
}
