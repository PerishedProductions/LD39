using LD39.Managers;
using System;
using System.Collections.Generic;

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
            feedback.Add("The music command is used to configure the audio player.");
            feedback.Add("Music makes the world go round.");

            commandAction(feedback);
        }

        public override void DisplayUsage()
        {
            feedback.Add("Usage: music [-s] [-p]");
            feedback.Add("Optional argument: -s or -start");
            feedback.Add("Start the music.");
            feedback.Add("Optional argument: -p or -pause");
            feedback.Add("Pause the music.");

            commandAction(feedback);
        }

        public override bool HasRequiredArguments(Dictionary<string, string> arguments)
        {
            if (arguments.ContainsKey("-s") || arguments.ContainsKey("-start") || arguments.ContainsKey("-p") || arguments.ContainsKey("-pause"))
            {
                return true;
            }
            return false;
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
