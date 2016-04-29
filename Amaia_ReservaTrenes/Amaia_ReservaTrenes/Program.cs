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
    using CrossCutting.Models;
    class Program
    {
        private static HttpClient client;

        static void Main(string[] args)
        {
            InitializeHttpClient();
            var exit = false;
            do
            {
                //Console.WriteLine(Display.AskOrderToUser);
                //Console.WriteLine(Display.Order);
                try
                {
                    string value = Console.ReadLine();
                    Train option = (Train)Enum.Parse(typeof(Train), value.ToUpper());
                    exit = MenuAction(option, exit);
                }
                catch (Exception)
                {
                    //Console.WriteLine(Exceptions.LetterAskException);
                }
            } while (!exit);
        }

        public static bool MenuAction(Train option, bool exit)
        {
            switch (option)
            {
                case Train.Express_2000:
                    MakeReservation(Train.Express_2000).Wait();
                    break;
                case Train.Local_1000:
                    MakeReservation(Train.Local_1000).Wait();
                    break;
                case Train.Exit:
                    exit = true;
                    break;
                default:
                    break;
            }

            return exit;
        }

        private static void InitializeHttpClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(Constants.Url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async static Task MakeReservation(Train trainChoice)
        {
            try
            {
                //TODO: Pedir al usuario en que tren quiere viajar y el número de asientos
                var reservationModel = new ReserveModel();

                var reservation = new TrainReservation(client);
                reservationModel.booking_reference = await reservation.GetReservationReference();

                var factoryTrainInfo = TrainInformationFactory.GetTrainInfo(trainChoice);
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

                coachHandler.HandleReservationRequest(train, reservation);

                /*
                 coachHandler.HandleReservationRequest(train, reservation); me devuelva los asientos y luego yo llamar para hacer la reserva

                o que el handler ya haga toda la reserva

                 */


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
