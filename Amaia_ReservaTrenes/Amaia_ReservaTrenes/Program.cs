namespace Amaia_ReservaTrenes
{
    using CrossCutting.Enum;
    using System.Net.Http;
    using TrainWebService;

    class Program
    {
        static HttpClient client;
        static UserConsoleDatas userDatas;
        static Service service;

        static void Main(string[] args)
        {
            service = new Service();
            client = service.InitializeHttpClient();
            userDatas = new UserConsoleDatas();
            //TODO En los enum los numeros se comportan de una manera rara (si pones un número muy largo la consola se va)
            Start();

        }

        private static void Start()
        {
            var choice = userDatas.AskUserForMainOptions();
            MenuAction(choice);
        }

        private static void MenuAction(ChoiceMenu option)
        {
            switch (option)
            {
                case ChoiceMenu.R:
                    AskForTrainProperties();
                    break;
                case ChoiceMenu.S:
                    break;
                case ChoiceMenu.B:
                    //TODO limpiar todos los datos
                    Start();
                    break;
                default:
                    break;
            }
        }

        private static void AskForTrainProperties()
        {
            var train = userDatas.AskUserForChooseTrain();
            var seatsNumber = userDatas.AskUserForHowManySeats();
            //Todo Mirar si el número que ha metido es mayor que 0, si es cero o negativo, throw Exceptions
            StartReservation(train, seatsNumber);
        }

        private static void StartReservation(Train train, int seatNumber)
        {
            var trainReservation = new TrainReservation(client, service);
            switch (train)
            {
                case Train.E:
                    trainReservation.DoReservation(Train.E, seatNumber).Wait();
                    break;
                case Train.L:
                    trainReservation.DoReservation(Train.L, seatNumber).Wait();
                    break;
                default:
                    break;
            }
        }
    }
}
