namespace Amaia_ReservaTrenes.ReservationHandler
{
    using CrossCutting.Constants;
    using CrossCutting.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;

    public class CoachHandler : Handler
    {
        public override void HandleReservationRequest(Dictionary<string, SeatProperty> seats, ReserveModel reservationReference, int numberSeats, HttpClient client)
        {
            var bookSeats = seats.Where(x => !string.IsNullOrEmpty(x.Value.booking_reference)).Count();
            var percentageOfBooking = (seats.Count() - bookSeats) / 100;
            if (percentageOfBooking < Constants.Percentage)
            {
                //return new List<string>();

            }
            else if (successor != null)
            {
                successor.HandleReservationRequest(seats, reservationReference, numberSeats, client);
            }
        }

        private void FindSeatsTogether() {

            

        }
    }
}
