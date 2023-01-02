using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils;
using Weather.Cli.Api;
using Weather.Cli.Models;
using Weather.Cli.Primitives;

namespace Weather.Cli.Commands;

[Command(Name = "current", Description = "Gets the current weather")]
public class CurrentWeatherCommand : CommandBase
{
    private readonly IWeatherApi _weatherApi;
    private readonly IConsole _console;

    public CurrentWeatherCommand(IWeatherApi weatherApi, IConsole console)
    {
        _weatherApi = weatherApi;
        _console = console;
    }

    public override async Task<int> OnExecute(CommandLineApplication app)
    {
        var response = await _weatherApi.GetCurrentWeather(City);
        var dto = WeatherDto.FromResponse(response, GetUnit());
        _console.ForegroundColor = ConsoleColor.DarkMagenta;
        _console.WriteLine($"Weather for {City}");
        _console.WriteLine("Min \t Max");

        _console.ResetColor();
        _console.WriteLine($"{dto.Minimum}\t{dto.Maximum}");

        return 0;
    }

    [Option("-c|--city", Description = "The city you're requesting the weather for.")]
    [Required]
    public string City { get; set; } = string.Empty;

    [Option("-u|--units", Description = "Temperature units")]
    [AllowedValues("metric", "emperial")]
    public string Units { get; set; } = "metric";

    private WeatherUnit GetUnit()
    {
        return Units.ToLowerInvariant() switch
        {
            "metric" => WeatherUnit.Metric,
            "emperial" => WeatherUnit.Emperial,
            _ => throw new ArgumentException($"invalid units '{Units}'", nameof(Units))
        };
    }
}