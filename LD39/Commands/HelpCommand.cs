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

        public override void PerformCommand()
        {
            List<string> feedback = new List<string>();

            feedback.Add("I am here to help you become a good little hacker.");
            feedback.Add("Your task is to hack the power stations in the region and cause a power outage.");
            feedback.Add("Reason: Because you can!");

            commandAction(feedback);
        }
    }
}
