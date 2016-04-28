namespace CrossCutting.Constants
{
    public static class Constants
    {
        public static string Localhost = "http://localhost:9600/";
        public static string DataTrain = "data_for_train";

        public static class TrainInfo
        {
            public static string Express2000 = Localhost + DataTrain + "express_2000";
            public static string Local1000 = Localhost + DataTrain + "local_1000";
        }
    }
}
