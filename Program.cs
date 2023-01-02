using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Weather.Cli.Api;
using Weather.Cli.Commands;

[Command(Name = "weather", Description = "Weather Api")]
[Subcommand(typeof(CurrentWeatherCommand))]
class Program : CommandBase
{
    private readonly IConsole _console;

    public Program(IConsole console)
    {
        _console = console;
    }

    public static async Task<int> Main(string[] args)
    {
        return await new HostBuilder()
        .ConfigureServices((_, services) =>
        {
            services.AddSingleton<IWeatherApi, FakeWeatherApi>()
            .AddSingleton(PhysicalConsole.Singleton);
        }).RunCommandLineApplicationAsync<Program>(args);
    }

    public override Task<int> OnExecute(CommandLineApplication app)
    {
        _console.ForegroundColor = ConsoleColor.Magenta;
        _console.WriteLine(@"
 __      __               __  .__                    _____         .__ 
/  \    /  \ ____ _____ _/  |_|  |__   ___________  /  _  \ ______ |__|
\   \/\/   // __ \\__  \\   __\  |  \_/ __ \_  __ \/  /_\  \\____ \|  |
 \        /\  ___/ / __ \|  | |   Y  \  ___/|  | \/    |    \  |_> >  |
  \__/\  /  \___  >____  /__| |___|  /\___  >__|  \____|__  /   __/|__|
       \/       \/     \/          \/     \/              \/|__|       
");
        _console.ResetColor();
        return base.OnExecute(app);
    }
}
