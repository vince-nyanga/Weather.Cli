using McMaster.Extensions.CommandLineUtils;

namespace Weather.Cli.Commands;

[HelpOption("--help")]
public class CommandBase
{
    public virtual Task<int> OnExecute(CommandLineApplication app)
    {
        app.ShowHelp();
        return Task.FromResult(0);
    }
}