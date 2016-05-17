namespace Amaia_ReservaTrenes
{
    using CrossCutting.Enum;
    using CrossCutting.Models;
    using CrossCutting.Resources;
    using ReservationHandler;
    using System;
    using System.Threading.Tasks;
    using TrainWebService;
    using System.Linq;

    public class TrainReservation
    {
        Service service;

        public TrainReservation(Service _service)
        {
            this.service = _service;
        }

        public async Task DoReservation(Train train, int seatNumber)
        {
            try
            {
                var reservationModel = new ReserveModel();
                reservationModel.train_id = train.AsDisplayString();
                reservationModel.booking_reference = await this.service.GetReservationReference();
                var trainInfo = await this.service.GetTrainInformation(train);

                Handler coachHandler = new CoachHandler();
                Handler trainHandler = new TrainHandler();
                coachHandler.SetSuccessor(trainHandler);
                coachHandler.HandleReservationRequest(trainInfo, reservationModel, seatNumber, this.service);
                this.PrintUserInfoBooking(reservationModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        private void PrintUserInfoBooking(ReserveModel reservationModel)
        {
            Console.WriteLine(string.Format(Display.SeatBookingComplete, reservationModel.train_id, string.Join(",", reservationModel.seats)));
        }
    }
}
