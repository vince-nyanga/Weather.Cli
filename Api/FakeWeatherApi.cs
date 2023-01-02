using Weather.Cli.Api.Responses;

namespace Weather.Cli.Api;
public class FakeWeatherApi : IWeatherApi
{
    private static readonly Random s_Random = new Random();

    public ValueTask<WeatherResponse> GetCurrentWeather(string city)
    {
        if (string.IsNullOrWhiteSpace(city))
        {
            throw new ArgumentException("city cannot be empty.", nameof(city));
        }

        var response = GenerateRandomWeather();

        return ValueTask.FromResult(response);
    }

    public ValueTask<IEnumerable<WeatherResponse>> GetForecast(string city, int numberOfDays = 5)
    {
        var forecast = Enumerable.Range(0, numberOfDays)
        .Select(_ => GenerateRandomWeather());

        return ValueTask.FromResult(forecast);
    }

    private static WeatherResponse GenerateRandomWeather()
    {
        return new WeatherResponse(s_Random.Next(-20, 14), s_Random.Next(15, 40));
    }
}