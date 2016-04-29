namespace Amaia_ReservaTrenes.ReservationHandler
{
    using CrossCutting.Constants;
    using CrossCutting.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CoachHandler : Handler
    {
        public override void HandleReservationRequest(Dictionary<string, SeatProperty> seats, TrainReservation reservation)
        {
            var bookSeats = seats.Where(x => !string.IsNullOrEmpty(x.Value.booking_reference)).Count();
            var percentageOfBooking = (seats.Count() - bookSeats) / 100;

            if (percentageOfBooking < Constants.Percentage)
            {
                Console.WriteLine("Booked: {0} of {1}, percentage booked: {2}", bookSeats, seats.Count(), percentageOfBooking);
                Console.WriteLine("{0} handled request The coach Can Book!! :D", this.GetType().Name);
            }

            else if (successor != null)
            {
                successor.HandleReservationRequest(seats, reservation);
            }
        }
    }
}
