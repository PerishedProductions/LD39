using System;
using System.Collections.Generic;

namespace LD39.Commands
{
    public class CommandsCommand : Command
    {
        private Dictionary<string, Command> commands;

        public CommandsCommand(Action<List<string>> commandCallback, Dictionary<string, Command> commandsList) : base(commandCallback)
        {
            Name = "commands";

            commands = commandsList;
        }

        public override void DisplayHelp()
        {
            feedback.Add("The commands command displays a list of available commands.");

            PerformCommandWithoutArguments();
        }

        public override void DisplayUsage()
        {
            feedback.Add("Usage: commands");
            feedback.Add("Simple yet effective");

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
            feedback.Add("Command List");
            feedback.Add("------------");

            foreach (var item in commands)
            {
                if (!item.Value.IsHidden)
                {
                    feedback.Add(item.Key);
                }
            }
            feedback.Add("------------");
            feedback.Add("Use the following optional arguments on the command for more info on the command: -u <usage>, -h <help>");
            commandAction(feedback);
        }
    }
}
