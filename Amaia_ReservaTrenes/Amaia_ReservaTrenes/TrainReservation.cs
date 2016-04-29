namespace Amaia_ReservaTrenes
{
    using CrossCutting.Constants;
    using CrossCutting.Models;
    using CrossCutting.Resources;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class TrainReservation
    {
        private HttpClient client;

        public TrainReservation(HttpClient _client)
        {
            this.client = _client;
        }

        public async Task<string> GetReservationReference()
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

        public async Task DoReservation(ReserveModel reserve)
        {
            try
            {
                var response = await client.PostAsJsonAsync(Constants.TrainReservation.MakeReservation, reserve);
            }
            catch (Exception)
            {
                throw new Exception(Exceptions.ConnectionGettingErrors);
            }
        }
    }
}
