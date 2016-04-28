namespace Amaia_ReservaTrenes
{
    using CrossCutting.Constants;
    using CrossCutting.Resources;
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class TrainReservation
    {
        private HttpClient client;

        public TrainReservation(HttpClient _client)
        {
            this.client = _client;
        }

        public async Task<string> GetTrainReservationReference()
        {
            HttpResponseMessage response = await client.GetAsync(Constants.TrainReservation.Reservation);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<string>(result);
            }
            else
            {
                throw new Exception(Exceptions.ConnectionGettingErrors);
            }
        }
    }
}
