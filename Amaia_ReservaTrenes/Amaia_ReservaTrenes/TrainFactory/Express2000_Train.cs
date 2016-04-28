namespace Amaia_ReservaTrenes.TrainFactory
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Linq;
    using System;
    using CrossCutting.Resources;
    using CrossCutting.Constants;

    public class Express2000_Train : ITrainInformation
    {
        public async Task<Dictionary<string, SeatProperty>> GetInformation(HttpClient client)
        {
            HttpResponseMessage response = await client.GetAsync(Constants.TrainInfo.Express2000);

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
            else {
                throw new Exception(Exceptions.ConnectionGettingErrors);
            }
        }
    }
}
