using FrontApi.Interfaces;
using System.Net.Http.Headers;

namespace FrontApi.Clients
{
    public class Api3Client : IApi3Client
    {
        // NOTE: This would be in a configuration
        private const string APIBaseAddress = "https://localhost:7201/";

        public async Task<Employee?> GetEmployee(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(APIBaseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("/Employee?id=" + id);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Employee>();
                }

                return null;
            }
        }
    }
}
