using System;
using System.Collections.Generic;

namespace LD39.Commands
{
    public class HelpCommand : Command
    {
        public HelpCommand(Action<List<string>> commandCallback) : base(commandCallback)
        {
            Name = "help";
        }

        public override void DisplayHelp()
        {
            feedback.Add("TODO: Insert detailed help here");
            commandAction(feedback);
        }

        public override void DisplayUsage()
        {
            feedback.Add("Help command can be used with the following optional arguments: -u <usage>, -h <help>");
            commandAction(feedback);
        }

        public override bool HasRequiredArguments(List<string> arguments)
        {
            return false;
        }

        public override void PerformCommandWithArguments(List<string> arguments)
        {

        }

        public override void PerformCommandWithoutArguments()
        {
            feedback.Add("TODO: Insert basic help here.");
            commandAction(feedback);
        }
    }
}
