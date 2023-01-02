using Weather.Cli.Api.Responses;
using Weather.Cli.Primitives;

namespace Weather.Cli.Models;

public record WeatherDto
{
    public int Minimum { get; init; }

    public int Maximum { get; init; }

    public static WeatherDto FromResponse(WeatherResponse response, WeatherUnit unit = WeatherUnit.Metric)
    {
        return new WeatherDto
        {
            Minimum = unit == WeatherUnit.Metric ? response.Minimum : (response.Minimum * (9 / 5)) + 32,
            Maximum = unit == WeatherUnit.Metric ? response.Maximum : (response.Maximum * (9 / 5)) + 32
        };
    }
}