namespace Amaia_ReservaTrenes.TrainFactory
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface ITrainInformation
    {
        Task<Dictionary<string, SeatProperty>> GetInformation(HttpClient client);
    }
}
