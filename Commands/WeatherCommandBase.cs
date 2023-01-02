using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils;
using Weather.Cli.Api;
using Weather.Cli.Models;
using Weather.Cli.Primitives;

namespace Weather.Cli.Commands;

public abstract class WeatherCommandBase : CommandBase
{
    protected readonly IWeatherApi _weatherApi;
    protected readonly IConsole _console;

    protected WeatherCommandBase(IWeatherApi weatherApi, IConsole console)
    {
        _weatherApi = weatherApi;
        _console = console;
    }

    [Option("-c|--city", Description = "The city you need the weather for")]
    [Required]
    public string City { get; set; } = string.Empty;

    [Option("-u|--units", Description = "Temperature units")]
    public WeatherUnit Units { get; set; } = WeatherUnit.Metric;
}