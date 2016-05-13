namespace Amaia_ReservaTrenes.ReservationHandler
{
    using CrossCutting.Constants;
    using CrossCutting.Models;
    using CrossCutting.Resources;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TrainHandler : Handler
    {
        //public override void List<string> HandleReservationRequest(Dictionary<string, SeatProperty> seats, int numberSeats)
        //{
        //    var bookSeats = seats.Where(x => !string.IsNullOrEmpty(x.Value.booking_reference)).Count();
        //    var percentageOfBooking = (seats.Count() - bookSeats) / 100;

        //    if (percentageOfBooking < Constants.Percentage)
        //    {
        //        Console.WriteLine("Booked: {0} of {1}, percentage booked: {2}", bookSeats, seats.Count(), percentageOfBooking);
        //        Console.WriteLine("{0} handled request The coach Can Book!! :D", this.GetType().Name);

        //        return new List<string>();
        //    }

        //    else if (successor != null)
        //    {
        //        throw new Exception(Exceptions.CompletedReservationError);
        //    }
        //    return new List<string>();
        //}
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
                throw new Exception(Exceptions.CompletedReservationError);
            }

            return new List<string>();
        }
    }
}
