namespace Amaia_ReservaTrenes.ReservationHandler
{
    using CrossCutting.Constants;
    using CrossCutting.Models;
    using CrossCutting.Resources;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using TrainWebService;
    public class TrainHandler : Handler
    {
        public override void HandleReservationRequest(Dictionary<string, SeatProperty> trainInfo, ReserveModel reservationReference, int numberSeats, Service service)
        {
            var bookSeats = trainInfo.Where(x => !string.IsNullOrEmpty(x.Value.booking_reference)).Count();
            var percentageOfBooking = (trainInfo.Count() - bookSeats) / 100;
            if (percentageOfBooking < Constants.Percentage)
            {

            }
            else if (successor != null)
            {
                throw new Exception(ExceptionsMessage.CompletedReservationError);
            }
        }
    }
}
