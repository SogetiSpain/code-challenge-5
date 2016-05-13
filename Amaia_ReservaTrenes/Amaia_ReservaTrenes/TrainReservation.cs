namespace Amaia_ReservaTrenes
{
    using CrossCutting.Constants;
    using CrossCutting.Enum;
    using CrossCutting.Models;
    using CrossCutting.Resources;
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using TrainWebService;

    public class TrainReservation
    {
        HttpClient client;


        public TrainReservation(HttpClient _client)
        {
            this.client = _client;
        }


        public async Task MakeReservation(Train trainChoice, int seatNumber)
        {
            try
            {

                //TODO: Pedir al usuario en que tren quiere viajar y el número de asientos
                var reservationModel = new ReserveModel();
                reservationModel.train_id = trainChoice.AsDisplayString();

                var reservation = new TrainReservation(client);
                reservationModel.booking_reference = await reservation.GetReservationReference();

                //var factoryTrainInfo = TrainInformationFactory.GetTrainInfo(trainChoice);
                //var train = await factoryTrainInfo.GetInformation(client);

                //Handler coachHandler = new CoachHandler();
                //Handler trainHandler = new TrainHandler();
                //coachHandler.SetSuccessor(trainHandler);
                //coachHandler.HandleReservationRequest(train, reservation);

                /*
                 coachHandler.HandleReservationRequest(train, reservation); me devuelva los asientos y luego yo llamar para hacer la reserva

                o que el handler ya haga toda la reserva

                 */
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<string> GetReservationReference()
        {
            HttpResponseMessage response = await client.GetAsync(Constants.TrainReservationUrl.Reservation);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<string>(result);
            }
            else
            {
                throw new Exception(Exceptions.ConnectionGettingDataError);
            }
        }

        public async Task DoReservation(ReserveModel reserve)
        {
            try
            {
                var response = await client.PostAsJsonAsync(Constants.TrainReservationUrl.MakeReservation, reserve);
            }
            catch (Exception)
            {
                throw new Exception(Exceptions.ConnectionGettingDataError);
            }
        }
    }
}
