using System;
using System.Collections.Generic;

namespace LD39.Commands
{
    public class CommandManager
    {
        public Action<List<string>> CommandFeedback { get; set; }

        public bool ParseCommand(string command)
        {
            List<string> feedback = new List<string>();

            if (command == "help" || command == "?")
            {
                feedback.Add("I am here to help you become a good little hacker.");
                feedback.Add("Your task is to hack the power stations in the region and cause a power outage.");
                feedback.Add("Reason: Because you can!");

                CommandFeedback(feedback);
                return true;
            }

            return false;
        }
    }
}
