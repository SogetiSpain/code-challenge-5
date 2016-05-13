namespace CrossCutting.Enum
{
    using Constants;

    public enum Train
    {
        E,
        L
    }

    public static class DisplayTrainAsText
    {
        public static string AsDisplayString(this Train type)
        {
            string text = string.Empty;

            switch (type)
            {
                case Train.E:
                    text = Constants.TrainId.Express2000;
                    break;
                case Train.L:
                    text = Constants.TrainId.Local1000;
                    break;
                default:
                    break;
            }
            return text;
        }
    }
}
