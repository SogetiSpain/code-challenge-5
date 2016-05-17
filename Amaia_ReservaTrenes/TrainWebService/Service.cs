namespace TrainWebService
{
    using CrossCutting.Constants;
    using CrossCutting.Enum;
    using CrossCutting.Models;
    using CrossCutting.Resources;
    using Factories;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class Service
    {
        HttpClient client;

        public void InitializeHttpClient()
        {
            try
            {
                client = new HttpClient();
                client.BaseAddress = new Uri(Constants.Url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            catch (Exception)
            {
                throw new Exception(ExceptionsMessage.ConnectionError);
            }
        }

        public async Task<Dictionary<string, SeatProperty>> GetTrainInformation(Train train)
        {
            var trainInfoFactory = TrainInformationFactory.GetTrainInfo(train);
            return await trainInfoFactory.GetInformation(client);
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
                throw new Exception(ExceptionsMessage.ConnectionGettingDataError);
            }
        }

        public async Task AddReservation(ReserveModel reserve)
        {
            try
            {
                var response = await client.PostAsJsonAsync(Constants.TrainReservationUrl.MakeReservation, reserve);
            }
            catch (Exception)
            {
                throw new Exception(ExceptionsMessage.ConnectionGettingDataError);
            }
        }
    }
}
