namespace Amaia_ReservaTrenes
{
    using CrossCutting.Enum;
    using CrossCutting.Models;
    using CrossCutting.Resources;
    using ReservationHandler;
    using System;
    using System.Threading.Tasks;
    using TrainWebService;
    using Utils;

    public class TrainReservation
    {
        Service service;
        HandlerUtils utils;

        public TrainReservation(Service _service)
        {
            this.service = _service;
            this.utils = new HandlerUtils();
        }

        public async Task DoReservation(Train train, int seatNumber)
        {
            try
            {
                var reservationModel = new ReserveModel();
                reservationModel.train_id = train.AsDisplayString();
                reservationModel.booking_reference = await this.service.GetReservationReference();
                var trainInfo = await this.service.GetTrainInformation(train);

                Handler coachHandler = new CoachHandler(this.utils, this.service);
                Handler trainHandler = new TrainHandler(this.utils, this.service);
                coachHandler.SetSuccessor(trainHandler);
                coachHandler.HandleReservationRequest(trainInfo, reservationModel, seatNumber);
                this.PrintUserInfoBooking(reservationModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        void PrintUserInfoBooking(ReserveModel reservationModel)
        {
            Console.WriteLine(string.Format(Display.SeatBookingComplete, reservationModel.train_id, string.Join(",", reservationModel.seats)));
        }
    }
}
