namespace Amaia_ReservaTrenes.ReservationHandler
{
    using CrossCutting.Constants;
    using CrossCutting.Models;
    using CrossCutting.Resources;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;

    public class TrainHandler : Handler
    {
        public override void HandleReservationRequest(Dictionary<string, SeatProperty> seats, ReserveModel reservationReference, int numberSeats, HttpClient client)
        {
            var bookSeats = seats.Where(x => !string.IsNullOrEmpty(x.Value.booking_reference)).Count();
            var percentageOfBooking = (seats.Count() - bookSeats) / 100;
            if (percentageOfBooking < Constants.Percentage)
            {

            }
            else if (successor != null)
            {
                throw new Exception(Exceptions.CompletedReservationError);
            }
        }
    }
}
