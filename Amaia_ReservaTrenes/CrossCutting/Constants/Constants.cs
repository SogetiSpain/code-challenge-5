namespace CrossCutting.Constants
{
    public static class Constants
    {
        public static string Url = "http://localhost:9600/";
        static string DataTrain = "data_for_train/";

        public static class TrainId
        {
            public static string Express2000 = "express_2000";
            public static string Local1000 = "local_1000";
        }

        public static class TrainInfoUrl
        {
            public static string Express2000 = Url + DataTrain + TrainId.Express2000;
            public static string Local1000 = Url + DataTrain + TrainId.Local1000;
        }

        public static class TrainReservationUrl
        {
            public static string Reservation = Url + "booking_reference";
            public static string MakeReservation = Url + "reserve";
        }

        public static string CleanAll = Url + "reset/";

        public static double Percentage = 0.7;
    }
}
