namespace Amaia_ReservaTrenes
{
    using CrossCutting.Constants;
    using CrossCutting.Enum;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            CallToWebApi().Wait();
        }

        private static async Task CallToWebApi()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.Url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var reservation = new TrainReservation(client);
                    var reference = await reservation.GetTrainReservationReference();
                    
                    var factoryTrainInfo = TrainInformationFactory.GetTrainInfo(Train.Express_2000);
                    var a = await factoryTrainInfo.GetInformation(client);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
