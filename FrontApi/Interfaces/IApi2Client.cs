namespace FrontApi.Interfaces
{
    // NOTE: Ideally these would be made available through a versioned API client Nuget package
    
    /// <summary>
    /// Wrapper for making calls to API2.
    /// </summary>
    public interface IApi2Client
    {
        Task<IEnumerable<WeatherForecast>> GetForecasts();
    }

    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
