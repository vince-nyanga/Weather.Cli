using Weather.Cli.Api.Responses;

namespace Weather.Cli.Api;
public interface IWeatherApi
{
    ValueTask<WeatherResponse> GetCurrentWeather(string city);

    ValueTask<IEnumerable<WeatherResponse>> GetForecast(string city, int numberOfDays = 5);
}