namespace TrainWebService.Factories
{
    using CrossCutting.Enum;
    using CrossCutting.Resources;
    using System;
    using TrainFactory;

    public class TrainInformationFactory
    {
        static ITrainInformation GetInformation(Train train)
        {
            switch (train)
            {
                case Train.E:
                    return new Express2000_Train();

                case Train.L:
                    return new Local1000_Train();

                default:
                    throw new Exception(ExceptionsMessage.TrainChoiceError);
            }
        }

        public static ITrainInformation GetTrainInfo(Train train)
        {
            return GetInformation(train);
        }
    }
}
