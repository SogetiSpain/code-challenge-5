namespace Amaia_ReservaTrenes.ReservationHandler
{
    using CrossCutting.Constants;
    using CrossCutting.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class CoachHandler : Handler
    {
        public override List<string> HandleReservationRequest(Dictionary<string, SeatProperty> seats, int numberSeats)
        {
            var bookSeats = seats.Where(x => !string.IsNullOrEmpty(x.Value.booking_reference)).Count();
            var percentageOfBooking = (seats.Count() - bookSeats) / 100;
            if (percentageOfBooking < Constants.Percentage)
            {
                return new List<string>();

            }
            else if (successor != null)
            {
                return successor.HandleReservationRequest(seats, numberSeats);
            }

            return new List<string>();
        }

        private void FindSeatsTogether() {

            

        }
    }
}
