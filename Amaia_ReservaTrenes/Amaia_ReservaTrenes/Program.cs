namespace Amaia_ReservaTrenes
{
    using CrossCutting.Enum;
    using CrossCutting.Resources;
    using System;
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

        static void Start()
        {
            var choice = userDatas.AskUserForMainOptions();
            MenuAction(choice);
        }

        static void MenuAction(ChoiceMenu option)
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

        static void AskForTrainProperties()
        {
            var train = userDatas.AskUserForChooseTrain();
            var seatsNumber = userDatas.AskUserForHowManySeats();
            StartReservation(train, seatsNumber);
        }
        
        static void StartReservation(Train train, int seatNumber)
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

        static void AskForTrainToDelete()
        {
            var train = userDatas.AskUserForChooseTrain();
            service.CleanAllBooking(train).Wait();
            Console.WriteLine(string.Format(Display.CleanSuccess, train.AsDisplayString()));
        }
    }
}
