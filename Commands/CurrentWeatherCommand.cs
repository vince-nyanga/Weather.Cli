using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils;
using Weather.Cli.Api;
using Weather.Cli.Models;
using Weather.Cli.Primitives;

namespace Weather.Cli.Commands;

[Command(Name = "current", Description = "Gets the current weather")]
public class CurrentWeatherCommand : WeatherCommandBase
{
    public CurrentWeatherCommand(IWeatherApi weatherApi, IConsole console)
        : base(weatherApi, console)
    {
    }

    public override async Task<int> OnExecute(CommandLineApplication app)
    {
        var response = await _weatherApi.GetCurrentWeather(City);
        var dto = WeatherDto.FromResponse(response, Units);

        _console.WriteLine($"Weather for {City}");
        _console.WriteLine("Min\tMax");

        _console.WriteLine(dto);

        return 0;
    }

}