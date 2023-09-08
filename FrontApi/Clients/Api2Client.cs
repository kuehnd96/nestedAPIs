using FrontApi.Interfaces;
using System.Net.Http.Headers;

namespace FrontApi.Clients
{
    public class Api2Client : IApi2Client
    {
        // NOTE: This would be in a configuration
        private const string APIBaseAddress = "https://localhost:7099/";

        public async Task<IEnumerable<WeatherForecast>?> GetForecasts()
        {
            using (var client = new HttpClient()) 
            {
                client.BaseAddress = new Uri(APIBaseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("/WeatherForecast");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<WeatherForecast>>();
                }

                return null;
            }
        }
    }
}
