namespace Amaia_ReservaTrenes
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            CallToWebApi().Wait();
        }

        private static async Task CallToWebApi()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9600/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("http://localhost:9600/data_for_train/express_2000");

                    if (response.IsSuccessStatusCode)
                    {
                        var seats = await response.Content.ReadAsStringAsync();
                        var dict = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, SeatProperty>>>(seats);
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }

            }
        }
    }
}
