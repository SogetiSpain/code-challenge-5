namespace Amaia_ReservaTrenes
{
    using CrossCutting.Constants;
    using CrossCutting.Enum;
    using Newtonsoft.Json;
    using ReservationHandler;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Linq;

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
                    var reference = await reservation.GetReservationReference();
                    
                    var factoryTrainInfo = TrainInformationFactory.GetTrainInfo(Train.Express_2000);
                    var train = await factoryTrainInfo.GetInformation(client);

                    //Handler coachHandlerOld;


                    // Setup Chain of Responsibility
                    //foreach (var item in train.Select(x => x.Value.coach).Distinct())
                    //{
                    //    Handler coachHandler = new CoachHandler();
                    //    if (coachHandlerOld != null)
                    //    {
                    //        coachHandlerOld.SetSuccessor(coachHandler);
                    //        coachHandlerOld = coachHandler;
                    //    }

                    //}

                    Handler coachHandler = new CoachHandler();
                    Handler trainHandler = new TrainHandler();
                    coachHandler.SetSuccessor(trainHandler);

                    coachHandler.HandleReservationRequest(train);
                    
                    // Wait for user
                    Console.ReadKey();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
