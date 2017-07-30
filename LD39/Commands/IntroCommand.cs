using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD39.Commands
{
    public class IntroCommand : Command
    {
        public IntroCommand(Action<List<string>> commandCallback) : base(commandCallback)
        {
        }

        public override void DisplayHelp()
        {
            throw new NotImplementedException();
        }

        public override void DisplayUsage()
        {
            throw new NotImplementedException();
        }

        public override bool HasRequiredArguments(Dictionary<string, string> arguments)
        {
            throw new NotImplementedException();
        }

        public override void PerformCommandWithArguments(Dictionary<string, string> arguments)
        {
            throw new NotImplementedException();
        }

        public override void PerformCommandWithoutArguments()
        {
            throw new NotImplementedException();
        }
    }
}
