namespace Amaia_ReservaTrenes
{
    using CrossCutting.Enum;
    using CrossCutting.Resources;
    using System;
    using System.Net.Http;
    using TrainWebService;

    class Program
    {
        static UserConsoleDatas userDatas;
        static Service service;

        static void Main(string[] args)
        {
            service = new Service();
            service.InitializeHttpClient();
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
                    Start();
                    break;
                case ChoiceMenu.S:
                    break;
                case ChoiceMenu.B:
                    AskForTrainToDelete();
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
            var trainReservation = new TrainReservation(service);
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

        private static void AskForTrainToDelete()
        {
            var train = userDatas.AskUserForChooseTrain();
            service.CleanAllBooking(train).Wait();
            Console.WriteLine(string.Format(Display.CleanSuccess, train.AsDisplayString()));
        }
    }
}
