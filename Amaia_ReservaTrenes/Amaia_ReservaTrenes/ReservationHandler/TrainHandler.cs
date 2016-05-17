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
            this.CheckIfIsMoreThan70PercentBooking(trainInfo, numberSeats);

            //TODO que reserve en el coach que tenga sitio
        }

        public void CheckIfIsMoreThan70PercentBooking(IEnumerable<KeyValuePair<string, SeatProperty>> trainInfo, int numberSeats)
        {
            var bookSeats = trainInfo.Where(x => !string.IsNullOrEmpty(x.Value.booking_reference)).ToDictionary(x => x.Key, x => x.Value).Count();
            var percentageOfBooking = (bookSeats + numberSeats) / Convert.ToDouble(trainInfo.Count());
            if (percentageOfBooking > Constants.Percentage)
            {
                throw new Exception(ExceptionsMessage.CompletedReservationError);
            }
        }
    }
}
