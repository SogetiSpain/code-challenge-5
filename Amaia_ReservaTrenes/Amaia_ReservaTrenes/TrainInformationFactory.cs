namespace Amaia_ReservaTrenes
{
    using CrossCutting.Enum;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TrainFactory;

    public class TrainInformationFactory
    {
        private ITrainInformation GetInformation(Train train)
        {
            switch (train)
            {
                case Train.Express_2000:
                        return new Express2000_Train();

                case Train.Local_1000:
                        return new Local1000_Train();

                default:
                    //TODO Mirar
                    return new Express2000_Train();
            }
        }

        public ITrainInformation GetTrainInfo(Train train)
        {
           return GetInformation(train);
        }
    }
}
