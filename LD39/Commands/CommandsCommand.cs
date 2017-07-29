using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD39.Commands
{
    public class CommandsCommand : Command
    {
        public CommandsCommand(Action<List<string>> commandCallback) : base(commandCallback)
        {
            Name = "commands";
        }

        public override void DisplayHelp()
        {
            
        }

        public override void DisplayUsage()
        {
           
        }

        public override bool HasRequiredArguments(Dictionary<string, string> arguments)
        {
            return false;
        }

        public override void PerformCommandWithArguments(Dictionary<string, string> arguments)
        {
           
        }

        public override void PerformCommandWithoutArguments()
        {
            feedback.Add("Command List");
            feedback.Add("------------");
            feedback.Add("Help");
            feedback.Add("Screen");
            feedback.Add("Commands");
            feedback.Add("------------");
            feedback.Add("Use the following optional arguments on the command for more info on the command: -u <usage>, -h <help>");
            commandAction(feedback);
        }
    }
}
