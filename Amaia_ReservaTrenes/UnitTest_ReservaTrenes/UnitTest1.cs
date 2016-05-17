namespace UnitTest_ReservaTrenes
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TrainWebService;
    using CrossCutting.Enum;
    using System.Linq;
    
    [TestClass]
    public class UnitTest1
    {
        Service service;

        [TestInitialize]
        public void Initializer()
        {
            this.service = new Service();
            this.service.InitializeHttpClient();
        }

        [TestMethod]
        public void TrainWebService_CleanLocal100Train()
        {
            Train train = Train.L;
            service.CleanAllBooking(train).Wait();
            var info = service.GetTrainInformation(train).Result;

            Assert.AreEqual(0, info.Where(x => !string.IsNullOrEmpty(x.Value.booking_reference)).ToDictionary(x => x.Key, x => x.Value).Count());
        }
    }
}
