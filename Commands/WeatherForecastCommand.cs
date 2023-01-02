using McMaster.Extensions.CommandLineUtils;
using Weather.Cli.Api;
using Weather.Cli.Models;

namespace Weather.Cli.Commands;

[Command("forecast", Description = "Gets the weather forecast")]
public class WeatherForecastCommand : WeatherCommandBase
{
    public WeatherForecastCommand(IWeatherApi weatherApi, IConsole console)
        : base(weatherApi, console)
    {
    }

    [Option("-d|--days", Description = "The number of days the forecast should include")]
    public int NumberOfDays { get; set; } = 5;

    public override async Task<int> OnExecute(CommandLineApplication app)
    {
        var forecast = (await _weatherApi.GetForecast(City, NumberOfDays)).Select(x => WeatherDto.FromResponse(x, Units));

        _console.WriteLine("Min\tMax");
        foreach (var dto in forecast)
        {
            _console.WriteLine(dto);
        }
        return 0;
    }
}