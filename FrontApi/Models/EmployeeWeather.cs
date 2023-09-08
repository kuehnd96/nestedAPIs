using FrontApi.Interfaces;

namespace FrontApi.Models
{
    public class EmployeeWeather
    {
        public IEnumerable<WeatherForecast>? Forecasts { get; init; }
        public Employee? Employee { get; init; }
    }
}
