using System;
using System.Collections.Generic;

namespace LD39.Commands
{
    public class ScreenCommand : Command
    {
        private LD39.Entity.Console console;

        public ScreenCommand(Action<List<string>> commandCallback, LD39.Entity.Console consoleScreen) : base(commandCallback)
        {
            Name = "screen";
            console = consoleScreen;
        }

        public override void DisplayHelp()
        {
            feedback.Add("TODO: Insert help here");
            commandAction(feedback);
        }

        public override void DisplayUsage()
        {
            feedback.Add("Screen command can be used with: -r <reset> or -c <clear>");
            commandAction(feedback);
        }

        public override bool HasRequiredArguments(List<string> arguments)
        {
            return true;
        }

        public override void PerformCommandWithArguments(List<string> arguments)
        {
            if (arguments.Contains("-r") || arguments.Contains("-reset") || arguments.Contains("-c") || arguments.Contains("-clear"))
            {
                console.Clear();
            }
        }

        public override void PerformCommandWithoutArguments()
        {
            DisplayUsage();
        }
    }
}
