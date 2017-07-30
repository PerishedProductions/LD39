using LD39.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD39.Commands
{
    public class MusicCommand : Command
    {
        public MusicCommand(Action<List<string>> commandCallback) : base(commandCallback)
        {
            Name = "music";
        }

        public override void DisplayHelp()
        {
            feedback.Add("TODO: Insert help here");
            commandAction(feedback);
        }

        public override void DisplayUsage()
        {
            feedback.Add("TODO: Insert help here");
            commandAction(feedback);
        }

        public override bool HasRequiredArguments(Dictionary<string, string> arguments)
        {
            return true;
        }

        public override void PerformCommandWithArguments(Dictionary<string, string> arguments)
        {
            if (arguments.ContainsKey("-s") || arguments.ContainsKey("-start"))
            {
                GameManager.Instance.StartMusic();
                commandAction(null);
                return;
            }

            if (arguments.ContainsKey("-p") || arguments.ContainsKey("-pause"))
            {
                GameManager.Instance.StopMusic();
                commandAction(null);
                return;
            }

            commandAction(null);
        }

        public override void PerformCommandWithoutArguments()
        {
            DisplayUsage();
        }
    }
}
