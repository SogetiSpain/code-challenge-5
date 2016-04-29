namespace CrossCutting.Constants
{
    public static class Constants
    {
        public static string Url = "http://localhost:9600/";
        static string DataTrain = "data_for_train/";

        public static class TrainInfo
        {
            public static string Express2000 = Url + DataTrain + "express_2000";
            public static string Local1000 = Url + DataTrain + "local_1000";
        }

        public static class TrainReservation
        {
            public static string Reservation = Url + "booking_reference";
            public static string MakeReservation = Url + "reserve";
        }

        public static double Percentage = 0.7;
    }
}
