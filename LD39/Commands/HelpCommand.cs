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
            feedback.Add("The help command displays some helpful information...");

            commandAction(feedback);
        }

        public override void DisplayUsage()
        {
            feedback.Add("Usage: help [-test]");
            feedback.Add("Optional argument: -test");
            feedback.Add("Test..1..2..3. Is this thing working?");

            commandAction(feedback);
        }

        public override bool HasRequiredArguments(Dictionary<string, string> arguments)
        {
            if (arguments.ContainsKey("-test"))
            {
                return true;
            }

            return false;
        }

        public override void PerformCommandWithArguments(Dictionary<string, string> arguments)
        {
            string testValue = arguments["-test"];

            if (string.IsNullOrEmpty(testValue))
            {
                feedback.Add("You called help with the -test argument succesfully. In this case -test has no value assigned.");
            }
            else
            {
                feedback.Add($"You called help with the -test argument succesfully. In this case -test has a value assigned. Value='{testValue}'");
            }

            commandAction(feedback);
        }

        public override void PerformCommandWithoutArguments()
        {
            feedback.Add("This game is heavily focused around using the console.");
            feedback.Add("There are several commands available to perform your hacking deeds.");
            feedback.Add("Some can be used without any arguments, other may need them or even require them.");
            feedback.Add("It is usefull to know that all commands have a -h for a small description.");
            feedback.Add("Example: help -h");
            feedback.Add("There is also a standard -u for usage explanation for each command.");
            feedback.Add("Example: help -u");
            feedback.Add("In some situations arguments are used by the command. Sometimes these have values and other times they don't.");
            feedback.Add("Example without value: help -test");
            feedback.Add("Example with value: help -test=value");
            feedback.Add("To get yourself started. Try the examples and otherwise use the 'commands' command to retrieve a list of available commands");
            commandAction(feedback);
        }
    }
}
