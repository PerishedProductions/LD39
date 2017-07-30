using System;
using System.Collections.Generic;

namespace LD39.Commands
{
    public class BackdoorCommand : Command
    {
        public BackdoorCommand(Action<List<string>> commandCallback) : base(commandCallback)
        {
            Name = "backdoor";
        }

        public override void DisplayHelp()
        {
            feedback.Add("TODO: Insert help here");
            commandAction(feedback);
        }

        public override void DisplayUsage()
        {
            feedback.Add("Usage of 'debug': -c <cities");
            commandAction(feedback);
        }

        public override bool HasRequiredArguments(Dictionary<string, string> arguments)
        {
            return false;
        }

        public override void PerformCommandWithArguments(Dictionary<string, string> arguments)
        {
            DisplayHelp();
        }

        public override void PerformCommandWithoutArguments()
        {
            DisplayHelp();
        }
    }
}
