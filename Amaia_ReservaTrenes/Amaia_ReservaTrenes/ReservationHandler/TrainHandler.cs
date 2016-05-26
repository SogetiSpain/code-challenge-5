namespace Amaia_ReservaTrenes.ReservationHandler
{
    using CrossCutting.Constants;
    using CrossCutting.Models;
    using CrossCutting.Resources;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TrainWebService;
    using Utils;

    public class TrainHandler : Handler
    {
        HandlerUtils utils;
        Service service;

        public TrainHandler(HandlerUtils _utils, Service _service)
        {
            this.utils = _utils;
            this.service = _service;
        }

        public override void HandleReservationRequest(Dictionary<string, SeatProperty> trainInfo, ReserveModel reservationReference, int numberSeats)
        {
            this.CheckIfIsMoreThan70PercentBooking(trainInfo, numberSeats);
            this.CheckCoachAndBook(trainInfo, reservationReference, numberSeats);
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

        void CheckCoachAndBook(Dictionary<string, SeatProperty> trainInfo, ReserveModel reservationReference, int numberSeats)
        {
            bool hasBook = false;
            foreach (var coachInfo in trainInfo.Select(x => x.Value.coach).Distinct())
            {
                hasBook = this.HandleEachCoachReservation(trainInfo.Where(x => x.Value.coach.Equals(coachInfo)), reservationReference, numberSeats, coachInfo);
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

        bool HandleEachCoachReservation(IEnumerable<KeyValuePair<string, SeatProperty>> coachInfo, ReserveModel reservationReference, int numberSeats, string coach)
        {

            try
            {
                this.CheckIfHasSeatsFree(coachInfo, numberSeats);
                reservationReference.seats = this.utils.BookSeats(coachInfo, coach, numberSeats);
                this.utils.DoReservation(reservationReference, this.service);
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
    }
}
