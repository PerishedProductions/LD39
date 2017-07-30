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
            feedback.Add("The help command displays some helpfull information...");

            PerformCommandWithoutArguments();
        }

        public override void DisplayUsage()
        {
            feedback.Add("Usage: help");
            feedback.Add("No arguments, no nothing.");

            PerformCommandWithoutArguments();
        }

        public override bool HasRequiredArguments(Dictionary<string, string> arguments)
        {
            return false;
        }

        public override void PerformCommandWithArguments(Dictionary<string, string> arguments)
        {
            //Should never be called but just in case
            PerformCommandWithoutArguments();
        }

        public override void PerformCommandWithoutArguments()
        {
            feedback.Add("TODO: Insert basic help here.");
            commandAction(feedback);
        }
    }
}
