namespace Amaia_ReservaTrenes.TrainFactory
{
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface ITrainInformation
    {
        Task GetInformation(HttpClient client);
    }
}
