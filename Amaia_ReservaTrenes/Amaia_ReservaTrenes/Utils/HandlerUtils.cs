namespace Amaia_ReservaTrenes.Utils
{
    using CrossCutting.Models;
    using System.Collections.Generic;
    using System.Linq;
    using TrainWebService;

    public class HandlerUtils
    {
        public IEnumerable<string> BookSeats(IEnumerable<KeyValuePair<string, SeatProperty>> coachInfo, string coach, int numberSeats)
        {
            var seats = new List<string>();
            var freeSeats = coachInfo.Where(x => string.IsNullOrEmpty(x.Value.booking_reference)).ToDictionary(x => x.Key, x => x.Value).First();
            for (int i = 0; i < numberSeats; i++)
            {
                var num = freeSeats.Value.seat_number + i;
                seats.Add(num + coach);
            }

            return seats;
        }

        public void DoReservation(ReserveModel reservationReference, Service service)
        {
            service.AddReservation(reservationReference).Wait();
        }
    }
}
