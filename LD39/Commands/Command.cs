using System;
using System.Collections.Generic;

namespace LD39.Commands
{
    public abstract class Command
    {
        protected Action<List<string>> commandAction;
        public string Name { get; set; }

        public Command(Action<List<string>> commandCallback)
        {
            commandAction = commandCallback;
        }

        public abstract void PerformCommand();
    }
}
