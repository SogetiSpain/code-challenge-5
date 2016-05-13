namespace TrainWebService.Factories.TrainFactory
{
    using CrossCutting.Constants;
    using CrossCutting.Models;
    using CrossCutting.Resources;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class Local1000_Train : ITrainInformation
    {
        public async Task<Dictionary<string, SeatProperty>> GetInformation(HttpClient client)
        {
            HttpResponseMessage response = await client.GetAsync(Constants.TrainInfoUrl.Local1000);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var seats = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, SeatProperty>>>(result);
                    return seats.Values.First();
                }
                catch (Exception)
                {

                    throw new Exception(Exceptions.NoCoachError);
                }
            }
            else
            {
                throw new Exception(Exceptions.ConnectionGettingDataError);
            }
        }
    }
}
