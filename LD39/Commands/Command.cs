using System;
using System.Collections.Generic;

namespace LD39.Commands
{
    public abstract class Command
    {
        public string Name { get; set; }
        protected Action<List<string>> commandAction;
        protected List<string> feedback = new List<string>();

        public Command(Action<List<string>> commandCallback)
        {
            commandAction = commandCallback;
        }

        public void PerformCommand(List<string> arguments)
        {
            feedback = new List<string>();

            if (arguments != null && arguments.Count > 0)
            {
                if (arguments.Contains("-usage") || arguments.Contains("-u"))
                {
                    DisplayUsage();
                    return;
                }

                if (arguments.Contains("-help") || arguments.Contains("-h"))
                {
                    DisplayHelp();
                    return;
                }

                if (HasRequiredArguments(arguments))
                {
                    PerformCommandWithArguments(arguments);
                }
                else
                {
                    DisplayUsage();
                }
            }
            else
            {
                PerformCommandWithoutArguments();
            }
        }

        public abstract void PerformCommandWithArguments(List<string> arguments);
        public abstract void PerformCommandWithoutArguments();
        public abstract bool HasRequiredArguments(List<string> arguments);
        public abstract void DisplayUsage();
        public abstract void DisplayHelp();
    }
}
