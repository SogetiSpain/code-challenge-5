namespace Amaia_ReservaTrenes.ReservationHandler
{
    using CrossCutting.Constants;
    using CrossCutting.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using TrainWebService;

    public class CoachHandler : Handler
    {
        public override void HandleReservationRequest(Dictionary<string, SeatProperty> trainInfo, ReserveModel reservationReference, int numberSeats, Service service)
        {
            bool hasCoachHandleReservation = false;
            foreach (var coachInfo in trainInfo.Select(x => x.Value.coach).Distinct())
            {
                hasCoachHandleReservation = this.HandleEachCoachReservation(trainInfo.Where(x => x.Value.coach.Equals(coachInfo)), reservationReference, service, numberSeats, coachInfo);
                if (hasCoachHandleReservation)
                {
                    break;
                }
            }

            if (!hasCoachHandleReservation)
            {
                successor.HandleReservationRequest(trainInfo, reservationReference, numberSeats, service);
            }
        }

        bool HandleEachCoachReservation(IEnumerable<KeyValuePair<string, SeatProperty>> coachInfo, ReserveModel reservationReference, Service service, int numberSeats, string coach) {

            try
            {
                CheckIfIsMoreThan70PercentBooking(coachInfo, numberSeats);
                reservationReference.seats = this.BookSeats(coachInfo, coach, numberSeats);
                this.DoReservation(reservationReference, service);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        void CheckIfIsMoreThan70PercentBooking(IEnumerable<KeyValuePair<string, SeatProperty>> coachInfo, int numberSeats)
        {
            var bookSeats = coachInfo.Where(x => !string.IsNullOrEmpty(x.Value.booking_reference)).ToDictionary(x => x.Key, x => x.Value).Count();
            var percentageOfBooking = (bookSeats + numberSeats) / Convert.ToDouble(coachInfo.Count());
            if (percentageOfBooking > Constants.Percentage)
            {
                throw new Exception();
            }
        }

        IEnumerable<string> BookSeats(IEnumerable<KeyValuePair<string, SeatProperty>> coachInfo, string coach, int numberSeats)
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

        void DoReservation(ReserveModel reservationReference, Service service)
        {
            service.AddReservation(reservationReference).Wait();
        }
    }
}
