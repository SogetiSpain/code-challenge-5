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
            this.CheckCoachAndBook(trainInfo, reservationReference, numberSeats, service);
        }

        void CheckIfIsMoreThan70PercentBooking(Dictionary<string, SeatProperty> trainInfo, int numberSeats)
        {
            var bookSeats = trainInfo.Where(x => !string.IsNullOrEmpty(x.Value.booking_reference)).ToDictionary(x => x.Key, x => x.Value).Count();
            var percentageOfBooking = (bookSeats + numberSeats) / Convert.ToDouble(trainInfo.Count());
            if (percentageOfBooking > Constants.Percentage)
            {
                throw new Exception(ExceptionsMessage.CompletedReservationError);
            }
        }

        void CheckCoachAndBook(Dictionary<string, SeatProperty> trainInfo, ReserveModel reservationReference, int numberSeats, Service service)
        {
            bool hasBook = false;
            foreach (var coachInfo in trainInfo.Select(x => x.Value.coach).Distinct())
            {
                hasBook = this.HandleEachCoachReservation(trainInfo.Where(x => x.Value.coach.Equals(coachInfo)), reservationReference, service, numberSeats, coachInfo);
                if (hasBook)
                {
                    break;
                }
            }

            if (!hasBook)
            {
                throw new Exception(ExceptionsMessage.CompletedReservationError);
            }
        }

        bool HandleEachCoachReservation(IEnumerable<KeyValuePair<string, SeatProperty>> coachInfo, ReserveModel reservationReference, Service service, int numberSeats, string coach)
        {

            try
            {
                this.CheckIfHasSeatsFree(coachInfo, numberSeats);
                reservationReference.seats = this.BookSeats(coachInfo, coach, numberSeats);
                this.DoReservation(reservationReference, service);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        void CheckIfHasSeatsFree(IEnumerable<KeyValuePair<string, SeatProperty>> coachInfo, int numberSeats)
        {
            var bookSeats = coachInfo.Where(x => !string.IsNullOrEmpty(x.Value.booking_reference)).ToDictionary(x => x.Key, x => x.Value).Count();
            if ((bookSeats + numberSeats) > coachInfo.Count())
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
