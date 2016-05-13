namespace Amaia_ReservaTrenes
{
    using CrossCutting.Constants;
    using CrossCutting.Enum;
    using CrossCutting.Models;
    using CrossCutting.Resources;
    using Newtonsoft.Json;
    using ReservationHandler;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using TrainWebService;

    public class TrainReservation
    {
        HttpClient client;
        Service service;


        public TrainReservation(HttpClient _client, Service _service)
        {
            this.client = _client;
            this.service = _service;
        }

        public async Task DoReservation(Train train, int seatNumber)
        {
            try
            {
                var reservationModel = new ReserveModel();
                reservationModel.train_id = train.AsDisplayString();
                reservationModel.booking_reference = await this.service.GetReservationReference();
                var seats = await this.service.GetTrainInformation(train);

                Handler coachHandler = new CoachHandler();
                Handler trainHandler = new TrainHandler();
                coachHandler.SetSuccessor(trainHandler);
                coachHandler.HandleReservationRequest(seats, reservationModel, seatNumber, this.client);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
